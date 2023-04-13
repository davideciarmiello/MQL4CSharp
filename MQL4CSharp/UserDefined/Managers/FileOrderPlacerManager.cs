using MQL4CSharp.Base.MQL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MQL4CSharp.Util;
using MQL4CSharp.Base;
using MQL4CSharp.Base.Enums;
using mql4sharp.helpers;
using MQL4CSharp.UserDefined.Input;
using mqlsharp.Util;
using log4net;
using System.Threading;
using MQL4CSharp.Base.Exceptions;

namespace MQL4CSharp.UserDefined.Managers
{
    public class FileOrderPlacerManager : IDisposable
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(FileOrderPlacerManager));
        public MQLBaseExtended MqlBase { get; }

        public FileOrderPlacerManager(MQLBaseExtended mqlBase)
        {
            MqlBase = mqlBase;
            MqlBase.ExecCommandTimeout = 30000;
        }

        //come da fx blue
        //https://www.fxblue.com/appstore/u2/mt4-personal-trade-copier/user-guide
        public void InitConfigs(int magicnumber,
            string fileName,
            string customSymbolMappings,
            string customLotMultipliers,
            string permittedSymbols,
            double useFixedLotSize,
            double limitOrderExpirationMinutes,
            bool mirrorSLandTPChanges)
        {
            MagicNumber = magicnumber > 0 ? magicnumber : 145356;
            FileName = fileName;
            CustomSymbolMappings = GetKeyValueDict(customSymbolMappings, s => s);
            CustomLotMultipliers = GetKeyValueDict(customLotMultipliers, s => Convert.ToDouble(s.ParseDecimalNFromJsStr() ?? 0));
            PermittedSymbols = new HashSet<string>(GetKeyValueDict(permittedSymbols, s => s).Keys);
            IgnoredSymbols = new HashSet<string>();
            UseFixedLotSize = useFixedLotSize;
            MirrorSLandTPChanges = mirrorSLandTPChanges;
            LimitOrderExpirationMinutes = limitOrderExpirationMinutes;

            threadPool = new MQLThreadPool(0);
        }

        private MQLThreadPool threadPool;

        private ConcurrentDictionary<string, TValue> GetKeyValueDict<TValue>(string str, Func<string, TValue> valueGetter)
        {
            var dict = new ConcurrentDictionary<string, TValue>();
            if (string.IsNullOrEmpty(str))
                return dict;
            foreach (var s in str.Split(','))
            {
                var keyAndValue = s.Trim().Split('=').Select(x => x.Trim()).ToList();
                if (string.IsNullOrEmpty(keyAndValue.First()))
                    continue;
                var newValue = keyAndValue.Skip(1).FirstOrDefault();
                var valueCasted = valueGetter(newValue);
                dict.AddOrUpdate(keyAndValue.First(), s1 => valueCasted, (s1, s2) => valueCasted);
            }
            return dict;
        }

        public int MagicNumber { get; set; } = 145356;

        public string FileName { get; set; }
        public ConcurrentDictionary<string, string> CustomSymbolMappings { get; set; }
        public ConcurrentDictionary<string, double> CustomLotMultipliers { get; set; }
        public HashSet<string> PermittedSymbols { get; set; }
        public HashSet<string> IgnoredSymbols { get; set; }
        public double UseFixedLotSize { get; set; }
        public bool MirrorSLandTPChanges { get; set; }
        public double LimitOrderExpirationMinutes { get; set; }

        private void Log(string message)
        {
            LOG.Info(message);
            //try { MqlBase.Print(message); }
            //catch { /**/ }
        }

        private FileSystemWatcher _fileWatcher;
        public void MonitorFile()
        {
            if (disposed || _fileWatcher != null)
                return;
            var fileInfo = new FileInfo(FileName);
            if (!fileInfo.Directory.Exists)
                fileInfo.Directory.Create();
            var fileWatcher = new FileSystemWatcher(fileInfo.DirectoryName, fileInfo.Name);
            fileWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastAccess
                                       | NotifyFilters.LastWrite | NotifyFilters.Size;
            fileWatcher.IncludeSubdirectories = false;
            fileWatcher.Created += (sender, args) => Execute();
            fileWatcher.Changed += (sender, args) => Execute();
            fileWatcher.Renamed += (sender, args) => Execute();
            fileWatcher.EnableRaisingEvents = true;
            _fileWatcher = fileWatcher;
        }

        public void Execute()
        {
            threadPool.QueueWorkItem(ExecuteThread);
        }

        private object lockExecute = new object();
        private DateTime executedLastWriteTime;
        private bool executing;
        private void ExecuteThread()
        {
            if (disposed)
                return;
            if (MqlBase.executingOnDeinit)
            {
                Dispose();
                return;
            }
            if (executing)
                return;
            lock (lockExecute)
            {
                if (executing)
                    return;
                executing = true;
                try
                {
                    if (!File.Exists(FileName))
                        return;
                    var lastWriteTime = File.GetLastWriteTime(FileName);
                    if (executedLastWriteTime == lastWriteTime)
                        return;

                    List<FileOrderPlacerItem> lst = null;
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            lst = File.ReadAllText(FileName).FromJson<List<FileOrderPlacerItem>>();
                        }
                        catch (Exception)
                        {
                            //System.IO.IOException: Il processo non può accedere al file '' perché è in uso da un altro processo.
                            Thread.Sleep(50);
                            if (i == 9)
                                throw;
                        }
                    }
                    if (lst.Count == 0)
                    {
                        executedLastWriteTime = lastWriteTime;
                        return;
                    }

                    var anySuccess = false;
                    foreach (var item in lst.ToList())
                    {
                        try
                        {
                            ManageOrderItem(item);
                            lst.Remove(item);
                            anySuccess = true;
                        }
                        catch (Exception ex)
                        {
                            Log($"[ERROR] [{item.externalid}] {ex}");
                            LOG.Error(ex.Message, ex);
                            if (ex is System.TimeoutException)
                            {
                                Execute();
                                return;
                            }
                        }
                    }

                    //only if not changed again, clear file!
                    var newWriteTime = File.GetLastWriteTime(FileName);
                    if (newWriteTime == lastWriteTime && anySuccess)
                    {
                        File.WriteAllText(FileName, lst.ToJson());
                        executedLastWriteTime = File.GetLastWriteTime(FileName);
                    }
                }
                catch (Exception ex)
                {
                    //Log($"[ERROR] {ex}");
                    LOG.Error(ex.Message, ex);
                }
                finally
                {
                    executing = false;
                }
            }
        }

        private List<string> BrokerSymbols;
        private string BrokerSymbolPrefix;
        private string BrokerSymbolSuffix;
        private void LoadSymbols()
        {
            if (BrokerSymbols != null)
                return;
            var lst = new List<string>();
            for (int i = 0; i < MqlBase.SymbolsTotal(false); i++)
            {
                var currencySymbol = MqlBase.SymbolName(i, false);
                lst.Add(currencySymbol);
                if (currencySymbol.Contains("EURUSD") || currencySymbol.Contains("USDCAD"))
                {
                    var prefixAndSuffix = currencySymbol.Replace("EURUSD", "|").Replace("USDCAD", "|").Split('|');
                    if (prefixAndSuffix.Length == 2)
                    {
                        BrokerSymbolPrefix = prefixAndSuffix[0];
                        BrokerSymbolSuffix = prefixAndSuffix[1];
                    }
                }
            }
            BrokerSymbols = lst;

            LOG.Debug($"Loaded Broker Symbols: {lst.Join("; ")}. Prefix: '{BrokerSymbolPrefix}'. Suffix: '{BrokerSymbolSuffix}'.");

            foreach (var keyValue in CustomSymbolMappings.ToList())
                CustomSymbolMappings.TryAdd(FindMatchSymbol(keyValue.Key) ?? keyValue.Key, keyValue.Value);
            foreach (var keyValue in CustomLotMultipliers.ToList())
                CustomLotMultipliers.TryAdd(FindMatchSymbol(keyValue.Key) ?? keyValue.Key, keyValue.Value);
            var itemsToAdd = PermittedSymbols.Select(x => new { symbol = FindMatchSymbol(x), x }).Where(x => x.symbol != null && x.symbol != x.x).Select(x => x.symbol).ToList(); ;
            itemsToAdd.ForEach(x => PermittedSymbols.Add(x));
            itemsToAdd = IgnoredSymbols.Select(x => new { symbol = FindMatchSymbol(x), x }).Where(x => x.symbol != null && x.symbol != x.x).Select(x => x.symbol).ToList();
            itemsToAdd.ForEach(x => IgnoredSymbols.Add(x));
        }


        private readonly ConcurrentDictionary<string, string> findMatchSymbolCache = new ConcurrentDictionary<string, string>();
        private string FindMatchSymbol(string s)
        {
            var res = findMatchSymbolCache.GetOrAdd(s, symbol =>
            {
                if (BrokerSymbols.Contains(symbol))
                    return symbol;
                var finded = BrokerSymbols.FirstOrDefault(x => x.Equals(symbol, StringComparison.OrdinalIgnoreCase));
                if (finded != null)
                    return finded;
                finded = BrokerSymbols.FirstOrDefault(x => x.Equals($"{BrokerSymbolPrefix}{symbol}{BrokerSymbolSuffix}", StringComparison.OrdinalIgnoreCase));
                if (finded != null)
                    return finded;
                if (symbol.Contains("/"))
                {
                    finded = FindMatchSymbol(symbol.Replace("/", ""));
                    if (finded != null)
                        return finded;
                }
                return null;
            });
            return res;
        }

        private void ManageOrderItem(FileOrderPlacerItem item)
        {
            if (string.IsNullOrEmpty(item.externalid) && item.ticket.GetValueOrDefault() == 0)
            {
                Log("Order item ignored: no externalid/ticket specified.");
                return;
            }

            if (item.closeDate.HasValue)
            {
                if (OrderIsAlreadyClosedFromThisProcess(item))
                {
                    Log($"Order item {item.externalid} closing ignored: already closed.");
                    return;
                }
                //Log($"Order closing: [{item.externalid}] - OrderSelect: {OrderSelect(item)} - OrderIsClosed: {OrderIsClosed()}");
                var orderSelect = OrderSelect(item) || OrderSelect(item);
                if ((orderSelect && !OrderIsClosed()) || item.ticket > 0)
                {
                    try
                    {
                        MqlBase.OrderClose(item.ticket.Value, 5);
                        Log($"Order closed: [{item.externalid}] - ticket: {item.ticket} - {item.symbol} {item.type}");
                    }
                    catch (Exception ex)
                    {
                        if (!OrderIsClosed())
                            throw;
                    }
                }
                else
                {
                    Log($"Order closing ignored: [{item.externalid}] - Ticket: {GetTicketCached(item)} - OrderSelect: {orderSelect} - OrderIsClosed: {OrderIsClosed()}");
                }
                if (!string.IsNullOrEmpty(item.externalid))
                    ordersClosed.Add(item.externalid);
                if (item.ticket > 0)
                    ordersClosed.Add(item.ticket.ToString());
                return;
            }

            if (string.IsNullOrEmpty(item.symbol))
            {
                Log("Order item ignored: no symbol specified.");
                return;
            }

            LoadSymbols();

            var originalSymbol = item.symbol;
            item.symbol = CustomSymbolMappings.GetValueOrDefault(item.symbol) ?? item.symbol;
            item.symbol = FindMatchSymbol(item.symbol) ?? item.symbol;

            if (PermittedSymbols.Any() && !PermittedSymbols.Contains(item.symbol))
            {
                Log($"Order item {item.externalid} symbol ignored ({item.symbol} not in PermittedSymbols).");
                return;
            }
            if (IgnoredSymbols.Contains(item.symbol))
            {
                Log($"Order item {item.externalid} symbol ignored ({item.symbol} in IgnoredSymbols).");
                return;
            }

            if (!BrokerSymbols.Contains(item.symbol))
            {
                IgnoredSymbols.Add(item.symbol);
                var msg = $"Symbol {item.symbol} not found. If required, add mapping to {nameof(CustomSymbolMappings)}.";
                MqlBase.Alert(msg);
                Log(msg);
                return;
            }

            var lotMultipliers = CustomLotMultipliers.GetValueOrDefault(CustomLotMultipliers.ContainsKey(originalSymbol) ? originalSymbol : item.symbol);
            if (lotMultipliers != 0)
                item.size = lotMultipliers * item.size;
            if (UseFixedLotSize != 0)
                item.size = UseFixedLotSize;
            item.size = Math.Abs(item.size);

            if (GetTicketCached(item) == 0)
            {
                if (item.openDate.AddMinutes(LimitOrderExpirationMinutes) >= DateTime.Now)
                {
                    if (!OrderSelect(item))
                    {
                        var op = TRADE_OPERATION.OP_BUY;
                        if (item.type?.StartsWith("sell", StringComparison.OrdinalIgnoreCase) == true)
                            op = TRADE_OPERATION.OP_SELL;
                        var cmd = (int)op;
                        var volume = item.size;
                        var price = MqlBase.SymbolInfoPrice(item.symbol, op == TRADE_OPERATION.OP_BUY);
                        var slippage = 5;
                        var stoploss = MirrorSLandTPChanges ? item.sl ?? 0 : 0;
                        var takeprofit = MirrorSLandTPChanges ? item.tp ?? 0 : 0;
                        var comment = item.externalid;
                        var expiration = DateUtil.FromUnixTime(0);
                        try
                        {
                            item.ticket = MqlBase.OrderSend(item.symbol, cmd, volume, price, slippage, stoploss, takeprofit, comment, MagicNumber, expiration, COLOR.AliceBlue);
                            Log($"Order opened: [{item.externalid}] {item.symbol} {item.type} {volume} ");
                            orderById.TryAdd(item.externalid, item);
                        }
                        catch (NotEnoughMoneyException ex)
                        {
                            item.ticket = -1;
                            orderById.TryAdd(item.externalid, item);
                            var msg = $"OrderSend failed: [{item.externalid}] {ex.Message}";
                            MqlBase.Alert(msg);
                            Log(msg);
                        }
                        return;
                    }
                    else
                    {
                        Log($"Order item add ignored: [{item.externalid}] Can't select.");
                    }
                }
                else
                {
                    Log($"Order item ignored: [{item.externalid}] Open date expired. OpenDate: {item.openDate} - LimitOrderExpirationMinutes: {LimitOrderExpirationMinutes}.");
                }
            }
            else
            {
                Log($"Order item add ignored: [{item.externalid}] Item already match a ticket {GetTicketCached(item)}.");
            }
        }

        private ConcurrentDictionary<string, FileOrderPlacerItem> orderById = new ConcurrentDictionary<string, FileOrderPlacerItem>();
        private ConcurrentBag<string> ordersClosed = new ConcurrentBag<string>();
        private bool OrderIsAlreadyClosedFromThisProcess(FileOrderPlacerItem order)
        {
            if (!string.IsNullOrEmpty(order.externalid) && ordersClosed.Contains(order.externalid))
                return true;
            if (order.ticket > 0 && ordersClosed.Contains(order.ticket.ToString()))
                return true;
            return false;
        }

        private bool OrderIsClosed()
        {
            var time = MqlBase.OrderCloseTime();
            return time.Year > 2000;
        }

        private bool OrderSelect(FileOrderPlacerItem order)
        {
            var ticket = GetTicketCached(order);
            if (ticket > 0)
            {
                if (MqlBase.OrderSelect(ticket, (int)SELECTION_TYPE.SELECT_BY_TICKET, (int)SELECTION_POOL.MODE_TRADES)
                    && MqlBase.OrderMagicNumber() == MagicNumber)
                {
                    order.ticket = ticket;
                    return true;
                }
            }

            if (string.IsNullOrEmpty(order.externalid))
                return false;

            var total = MqlBase.OrdersTotal();
            while (true)
            {
                for (int i = 0; i < total; i++)
                {
                    if (MqlBase.OrderSelect(i, (int)SELECTION_TYPE.SELECT_BY_POS, (int)SELECTION_POOL.MODE_TRADES)
                        && MqlBase.OrderMagicNumber() == MagicNumber)
                    {
                        var comment = MqlBase.OrderComment();
                        if (comment?.EndsWith(order.externalid) == true || order.externalid == comment)
                        {
                            order.ticket = MqlBase.OrderTicket();
                            orderById.TryAdd(order.externalid, order);
                            orderById[order.externalid].ticket = order.ticket;
                            return true;
                        }
                    }
                }
                var newTotal = MqlBase.OrdersTotal();
                if (newTotal == total)
                    break;
                total = newTotal;
            }

            return false;
        }

        private int GetTicketCached(FileOrderPlacerItem order)
        {
            var ticket = order.ticket.GetValueOrDefault();
            if (ticket == 0 && !string.IsNullOrEmpty(order.externalid))
                ticket = orderById.GetValueOrDefault(order.externalid)?.ticket ?? 0;
            return ticket;
        }

        private bool disposed;
        public void Dispose()
        {
            if (disposed)
                return;
            LOG.Info($"Disposing {FileName}");
            disposed = true;
            if (_fileWatcher != null)
            {
                _fileWatcher.EnableRaisingEvents = false;
                _fileWatcher.Dispose();
                _fileWatcher = null;
            }
        }
    }
}
