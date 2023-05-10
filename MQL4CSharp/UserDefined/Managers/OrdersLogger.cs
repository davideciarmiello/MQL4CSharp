using System;
using MQL4CSharp.Base.MQL;
using MQL4CSharp.UserDefined.Input;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.Util;
using mql4sharp.helpers;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using log4net;
using System.Reflection;

namespace MQL4CSharp.UserDefined.Managers
{
    public class OrdersLogger : IDisposable
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(OrdersLogger));

        public int MarketOpenHour { get; set; }
        public double AccountBalance { get; set; }
        public double AccountEquity { get; set; }
        public DateTime TimeCurrent { get; set; }

        public OrdersLogger() : this(0)
        {
        }
        public OrdersLogger(long chartId)
        {
            ChartId = chartId;
            OrdersTradeFiller = new OrdersFiller() { Parent = this, IsHistory = false };
            OrdersHistoryFiller = new OrdersFiller() { Parent = this, IsHistory = true };
            threadPool = new MQLThreadPool(ChartId);
        }

        private MQLThreadPool threadPool;
        private string reportSheetNameTemplate;
        private List<string> reportSheetNameFilters;
        public void Init(int accountNumber, string reportFileName
            , int marketOpenHour
            , string reportSheetNameTemplate
            , string reportSheetNameFilters
            , string magicMapping
        )
        {
            AccountNumber = accountNumber;

            if (!string.IsNullOrEmpty(reportFileName))
            {
                reportFileName = reportFileName.Replace("{AccountNumber}", AccountNumber.ToString())
                    .Replace("{accountnumber}", AccountNumber.ToString());
                if (!Path.IsPathRooted(reportFileName))
                    reportFileName = Path.Combine(CachedDataStorageInstance.GetTerminalDataPath(), "MQL4\\Files", reportFileName);
            }
            ReportFileName = reportFileName.AsNullIfEmpty();
            cacheFile = Path.Combine(CachedDataStorageInstance.GetTerminalDataPath(), "history", $"orderslogger_{accountNumber}.json");
            LoadFromCache();
            MarketOpenHour = marketOpenHour;
            this.reportSheetNameTemplate = reportSheetNameTemplate.AsNullIfEmpty() ?? "{symbol}-{magic:magicdescr}";
            this.reportSheetNameFilters = (reportSheetNameFilters + "").Split(',').Where(x => x != "").ToList();
            if (!string.IsNullOrEmpty(magicMapping) && File.Exists(magicMapping))
            {
                magicMappingFile = magicMapping;
                LoadMagicMappingFile();
            }
            else
            {
                this.magicMapping = magicMapping.SplitAsKeyValuePairs().Where(x => !string.IsNullOrEmpty(x.Key.Trim())).DistinctBy(x => x.Key)
                    .ToConcurrentDictionary(x => x.Key.Trim(), x => x.Value.Trim());
            }
        }

        private bool LoadMagicMappingFile()
        {
            if (string.IsNullOrEmpty(magicMappingFile) || !File.Exists(magicMappingFile))
                return false;
            if (magicMappingFileLastRead == File.GetLastWriteTime(magicMappingFile))
                return false;
            magicMappingFileLastRead = File.GetLastWriteTime(magicMappingFile);
            magicMapping = File.ReadAllLines(magicMappingFile)
                .Select(x => (" " + x).Split(new[] { " #", " //" }, StringSplitOptions.None).First().Trim()) //rimuovo i commenti
                .Where(x => !string.IsNullOrEmpty(x))
                .SelectMany(x => x.SplitAsKeyValuePairs())
                .Where(x => !string.IsNullOrEmpty(x.Key.Trim()))
                .DistinctBy(x => x.Key)
                .ToConcurrentDictionary(x => x.Key.Trim(), x => x.Value.Trim());
            getSheetNameCache.Clear();
            return true;
        }

        private void LoadFromCache()
        {
            try
            {
                if (!File.Exists(cacheFile))
                {
                    SaveToCache();
                    return;
                }
                var instance = File.ReadAllText(cacheFile).FromJson<OrdersLogger>();
                foreach (var orderDef in instance.HistoryOrders.Concat(instance.HistoryOrdersForCurrentDay))
                    OrdersHistoryFiller.ordersByTicket.TryAdd(orderDef.ticket, orderDef);
                foreach (var instanceSheetInfo in instance.SheetInfos)
                {
                    if (!instanceSheetInfo.Value.Changed)
                        instanceSheetInfo.Value.Changed = true;
                    SheetInfos.TryAdd(instanceSheetInfo.Key, instanceSheetInfo.Value);
                }
            }
            catch (Exception ex)
            {
                LOG.Error(ex);
            }
        }

        private string lastJson;
        private void SaveToCache()
        {
            lock (saveExcelLock)
            {
                //using (var mutex = new Mutex(true, $"MQL4.{nameof(OrdersLogger)}.{nameof(SaveToCache)}"))
                {
                    //mutex.WaitOne();
                    try
                    {
                        var json = this.ToJson();
                        if (json == lastJson)
                            return;

                        Directory.CreateDirectory(Path.GetDirectoryName(cacheFile));
                        File.WriteAllText(cacheFile, json);
                        lastJson = json;
                    }
                    catch (Exception ex)
                    {
                        LOG.Error(ex);
                    }
                }
            }
        }
        private string cacheFile;
        public void SetCurrentInfo(DateTime timeCurrent, double accountEquity, double accountBalance)
        {
            TimeCurrent = timeCurrent;
            AccountEquity = accountEquity;
            AccountBalance = accountBalance;

            var day = timeCurrent.Date;
            //var haveOpenHour = MarketOpenHour > 0 && MarketOpenHour < 24;
            //if (haveOpenHour && timeCurrent.Hour >= MarketOpenHour)
            //    day = day.AddDays(1);
            if (day != DayDate)
            {
                DayDate = day;
                DayMinDate = timeCurrent.Date != day ? day.AddHours(-24 + MarketOpenHour) : day;
                DayMaxDate = DayMinDate.AddDays(1).AddMilliseconds(-10);
                OpenedMarkets.Clear();
                lastPriceForDay.Clear();
            }
        }

        public long ChartId { get; set; }
        public string ReportFileName { get; set; }
        public int AccountNumber { get; set; }

        private ConcurrentDictionary<string, object> OpenedMarkets = new ConcurrentDictionary<string, object>();
        private ConcurrentDictionary<long, double> lastPriceForDay = new ConcurrentDictionary<long, double>();
        internal readonly OrdersFiller OrdersTradeFiller;
        internal readonly OrdersFiller OrdersHistoryFiller;

        public List<OrderDef> Orders { get; set; } = new List<OrderDef>();
        public List<OrderDef> HistoryOrders { get; set; } = new List<OrderDef>();
        public List<OrderDef> HistoryOrdersForCurrentDay { get; set; } = new List<OrderDef>();
        private string lastHistoryOrdersCacheKey;
        private string lastTradeOrdersCacheKey;
        public void FillingCompleted(List<OrderDef> orders, bool isHistory)
        {
            if (isHistory)
                HistoryOrders = orders;
            else
                Orders = orders;
            if (isHistory)
            {
                var historyOrdersCacheKey = $"{DayDate.Day}_{HistoryOrders.Count}_{HistoryOrders.FirstOrDefault()?.ticket}_{HistoryOrders.LastOrDefault()?.ticket}";
                if (lastHistoryOrdersCacheKey != historyOrdersCacheKey)
                {
                    HistoryOrdersForCurrentDay = HistoryOrders.Union(OrdersHistoryFiller.ordersByTicket.Values)
                        .Where(x => x.closetime.HasValue && x.closetime >= DayMinDate && x.closetime <= DayMaxDate).ToList();
                    foreach (var orderDef in HistoryOrdersForCurrentDay)
                        OpenedMarkets.TryAdd(orderDef.symbol, null);
                    lastHistoryOrdersCacheKey = historyOrdersCacheKey;
                }
            }
            else
            {
                foreach (var orderDef in Orders)
                {
                    var lastPrice = lastPriceForDay.GetOrAdd(orderDef.ticket, l => orderDef.closeprice);
                    if (lastPrice == orderDef.closeprice)
                        continue;
                    lastPriceForDay.AddOrUpdate(orderDef.ticket, l => orderDef.closeprice, (l, d) => orderDef.closeprice);
                    OpenedMarkets.TryAdd(orderDef.symbol, null);
                }
                var tradeCacheKey = $"{DayDate.Day}_{HistoryOrders.Count}_{Orders.Count}";
                var ordersFiltered = Orders.Concat(HistoryOrdersForCurrentDay)
                    .Where(x => x.type == TRADE_OPERATION.OP_BUY || x.type == TRADE_OPERATION.OP_SELL)
                    .Where(x => OpenedMarkets.ContainsKey(x.symbol)).ToList();
                if (reportSheetNameFilters.Any())
                {
                    ordersFiltered = ordersFiltered.Where(x =>
                    {
                        var sheetName = GetSheetName(x);
                        return reportSheetNameFilters.Any(f => sheetName.Contains(f));
                    }).ToList();
                }
                if (tradeCacheKey != lastHistoryOrdersCacheKey)
                    LoadMagicMappingFile();
                foreach (var group in ordersFiltered.GroupBy(x => "Summary"))
                    SetGroupInfoInModel(group);
                foreach (var group in ordersFiltered.GroupBy(GetSheetName))
                    SetGroupInfoInModel(group);
                var seconds = tradeCacheKey == lastTradeOrdersCacheKey ? 30 : 0;
                lastTradeOrdersCacheKey = tradeCacheKey;
                if (lastWriteDate.AddSeconds(seconds) < DateTime.Now)
                    threadPool.QueueWorkItem(() =>
                    {
                        if (lastWriteDate.AddSeconds(seconds) > DateTime.Now)
                            return;
                        lastWriteDate = DateTime.Now;
                        SaveToCache();
                        SaveExcel();
                    });
            }
        }

        private readonly ConcurrentDictionary<string, string> getSheetNameCache = new ConcurrentDictionary<string, string>();
        private string GetSheetName(OrderDef order)
        {
            var str = getSheetNameCache.GetOrAdd($"{order.symbol}_{order.magic}_{order.type}", s =>
            {
                var magicDescr = FindMagicDescr(order.magic.ToString()) ?? FindMagicDescr(order.comment) ?? (order.magic == 0 ? "Manual" : null);
                if (magicDescr == null && LoadMagicMappingFile())
                    magicDescr = FindMagicDescr(order.magic.ToString()) ?? FindMagicDescr(order.comment);
                var res = reportSheetNameTemplate
                        .Replace("{symbol}", order.symbol)
                        .Replace("{magic:magicdescr}", string.IsNullOrEmpty(magicDescr) ? order.magic.ToString() : magicDescr)
                        .Replace("{magic}", order.magic.ToString())
                        .Replace("{magicdescr}", magicDescr)
                        .Replace("{type}", order.type.ToString().Replace("OP_", "").ToLowerInvariant())
                    ;
                return res;
            });
            return str;
        }

        private string FindMagicDescr(string magic)
        {
            if (string.IsNullOrEmpty(magic))
                return null;
            var magicDescr = magicMapping.GetValueOrDefault(magic);
            if (magicDescr != null)
                return magicDescr;
            magicDescr = magicMapping
                .Where(x => x.Key.Contains("*"))
                .Where(x =>
                {
                    if (x.Key.StartsWith("*") && x.Key.EndsWith("*"))
                        return magic.Contains(x.Key.Trim('*'));
                    if (x.Key.StartsWith("*"))
                        return magic.EndsWith(x.Key.Trim('*'));
                    if (x.Key.EndsWith("*"))
                        return magic.StartsWith(x.Key.Trim('*'));
                    return false;
                })
                .Select(x => x.Value)
                .FirstOrDefault();
            return magicDescr;
        }

        private DateTime lastWriteDate;
        private void SetGroupInfoInModel(IGrouping<string, OrderDef> group)
        {
            var info = SheetInfos.GetOrAdd($"{DayDate}_{group.Key}", s => new SheetInfo() { Day = DayDate, KeyItem = group.First(), Key = group.Key, Changed = true });
            var ordersBuySell = group.Where(x => x.type == TRADE_OPERATION.OP_BUY || x.type == TRADE_OPERATION.OP_SELL).ToList();
            var ordersActive = ordersBuySell.Where(x => x.closetime == null).ToList();
            var ordersClosed = ordersBuySell.Where(x => x.closetime != null).ToList();
            var ordersClosedProfit = ordersClosed.Count == 0 ? 0 : ordersClosed.Select(x => x.profit + x.commission + x.swap).Sum();
            if (ordersActive.Any())
            {
                var equity = ordersActive.Select(x => x.profit + x.commission + x.swap).Sum();
                if (equity < info.MaxDd)
                {
                    info.MaxDd = equity;
                    info.MaxDdDate = TimeCurrent;
                    info.Changed = true;
                }
                if (equity > info.MaxEquity)
                {
                    info.MaxEquity = equity;
                    info.MaxEquityDate = TimeCurrent;
                    info.Changed = true;
                }
            }

            if (info.ClosedProfit != ordersClosedProfit)
            {
                info.ClosedProfit = ordersClosedProfit;
                info.Changed = true;
            }
        }

        public DateTime DayDate { get; set; }
        public DateTime DayMinDate { get; set; }
        public DateTime DayMaxDate { get; set; }
        public ConcurrentDictionary<string, SheetInfo> SheetInfos { get; set; } = new ConcurrentDictionary<string, SheetInfo>();
        private bool disposed;
        public void Dispose()
        {
            if (disposed)
                return;
            SaveToCache();
            SaveExcel();
            disposed = true;
        }

        private object saveExcelLock = new object();
        public void SaveExcel()
        {
            if (string.IsNullOrEmpty(ReportFileName) || disposed)
                return;
            lock (saveExcelLock)
                try
                {
                    var fi = new FileInfo(ReportFileName);
                    if (!File.Exists(ReportFileName))
                        Directory.CreateDirectory(fi.DirectoryName);
                    if (lastExcelSaveIsFileInUse && fi.IsFileLocked())
                    {
                        threadPool.QueueWorkItem(() =>
                        {
                            Thread.Sleep(5000);
                            SaveExcel();
                        });
                        return;
                    }

                    var sheetsChanged = SheetInfos.Where(x => x.Value.Changed).ToList();
                    if (!sheetsChanged.Any())
                        return;
                    var maxChangedDate = sheetsChanged.Max(x => x.Value.ChangedDate.GetValueOrDefault());

                    //using (var mutex = new Mutex(true, $"MQL4.{nameof(OrdersLogger)}.{nameof(SaveExcel)}"))
                    {
                        //mutex.WaitOne();

                        using (var package = new ExcelPackage(fi))
                        {
                            foreach (var sheetInfo in sheetsChanged.Select(x => x.Value).OrderBy(x => x.Key == "Summary" ? 0 : 1).ThenBy(x => x.Key))
                            {
                                var worksheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == sheetInfo.Key || x.Name.StartsWith($"{sheetInfo.Key},")) ??
                                                package.Workbook.Worksheets.Add(sheetInfo.Key);
                                worksheetHeadersIndex.Clear();
                                LoadOrSetHeaders(worksheet, nameof(SheetInfo.Day), nameof(SheetInfo.MaxDd), nameof(SheetInfo.MaxDdDate), nameof(SheetInfo.MaxEquity), nameof(SheetInfo.MaxEquityDate));
                                var colDay = worksheetHeadersIndex.GetValueOrDefault(nameof(SheetInfo.Day));

                                int rowStart = worksheet.Dimension.Start.Row;
                                int rowEnd = worksheet.Dimension.End.Row;
                                var cellDay = worksheet.Cells[rowStart, colDay, rowEnd, colDay].FirstOrDefault(x => sheetInfo.Day.Match(x.Value));
                                if (cellDay == null)
                                {
                                    cellDay = worksheet.Cells[rowEnd + 1, colDay];
                                    cellDay.Value = sheetInfo.Day;
                                    cellDay.Style.Numberformat.Format = "dd/MM/yyyy";
                                }
                                var rowNumber = cellDay.End.Row;
                                var cell = GetCell(worksheet, rowNumber, nameof(SheetInfo.MaxDd));
                                if (GetExcelDouble(cell).GetValueOrDefault(double.MaxValue) > sheetInfo.MaxDd)
                                {
                                    cell.Value = sheetInfo.MaxDd;
                                    cell = GetCell(worksheet, rowNumber, nameof(SheetInfo.MaxDdDate));
                                    cell.Value = sheetInfo.MaxDdDate;
                                    cell.Style.Numberformat.Format = "hh:mm:ss";
                                }
                                cell = GetCell(worksheet, rowNumber, nameof(SheetInfo.MaxEquity));
                                if (GetExcelDouble(cell).GetValueOrDefault(double.MinValue) < sheetInfo.MaxEquity)
                                {
                                    cell.Value = sheetInfo.MaxEquity;
                                    cell = GetCell(worksheet, rowNumber, nameof(SheetInfo.MaxEquityDate));
                                    cell.Value = sheetInfo.MaxEquityDate;
                                    cell.Style.Numberformat.Format = "hh:mm:ss";
                                }
                                cell = GetCell(worksheet, rowNumber, nameof(SheetInfo.ClosedProfit));
                                cell.Value = sheetInfo.ClosedProfit;
                                if (rowEnd < 10)
                                {
                                    worksheetHeadersIndex.Values.ToList().ForEach(x => worksheet.Column(x).AutoFit());
                                }
                            }
                            // do work here                            
                            package.Save();
                            lastExcelSaveIsFileInUse = false;
                        }
                    }


                    foreach (var keyValuePair in sheetsChanged.Where(x => x.Value.Changed && x.Value.ChangedDate <= maxChangedDate).ToList())
                        keyValuePair.Value.Changed = false;
                    foreach (var keyValuePair in sheetsChanged.Where(x => x.Value.Day < DateTime.Today.AddDays(-7)).ToList())
                    {
                        SheetInfo sheetInfo;
                        SheetInfos.TryRemove(keyValuePair.Key, out sheetInfo);
                    }
                }
                catch (Exception ex)
                {
                    var exIo = ex.GetWithAllInnerExceptions().OfType<IOException>().FirstOrDefault();
                    if (exIo != null && new FileInfo(ReportFileName).IsFileLocked()) //the file is in use
                    {
                        if (!lastExcelSaveIsFileInUse)
                            LOG.Info(ex);
                        lastExcelSaveIsFileInUse = true;
                        threadPool.QueueWorkItem(() =>
                        {
                            Thread.Sleep(5000);
                            SaveExcel();
                        });
                        return;
                    }
                    LOG.Error(ex);
                }
        }

        private bool lastExcelSaveIsFileInUse;

        private double? GetExcelDouble(ExcelWorksheet worksheet, int row, string column)
        {
            var cell = GetCell(worksheet, row, column);
            return GetExcelDouble(cell);
        }

        private static double? GetExcelDouble(ExcelRange cell)
        {
            var value = cell.Value;
            if (value == null)
                return null;
            return Convert.ToDouble(value);
        }

        private ExcelRange GetCell(ExcelWorksheet worksheet, int row, string column)
        {
            if (!worksheetHeadersIndex.ContainsKey(column))
                LoadOrSetHeaders(worksheet, column);
            var col = worksheetHeadersIndex.GetValueOrDefault(column);
            var cell = worksheet.Cells[row, col];
            return cell;
        }

        private int headerRow;
        private void LoadOrSetHeaders(ExcelWorksheet worksheet, params string[] headers)
        {
            if (worksheetHeadersIndex.Count == 0)
            {
                var headerCell = worksheet.Cells[1, 1, 10, 10].FirstOrDefault(x => headers.Contains(x.Value?.ToString() ?? ""));
                headerRow = headerCell?.End.Row ?? 0;
                if (headerRow == 0)
                    headerRow = 1;
            }

            for (int i = 1; i < 100; i++)
            {
                var value = worksheet.Cells[headerRow, i].Value?.ToString();
                if (!string.IsNullOrEmpty(value))
                    worksheetHeadersIndex.AddOrUpdate(value, s => i, (s, i1) => i);
            }

            foreach (var header in headers)
            {
                if (worksheetHeadersIndex.ContainsKey(header))
                    continue;
                var newIndex = (worksheetHeadersIndex.Count == 0 ? 0 : worksheetHeadersIndex.Select(x => x.Value).Max()) + 1;
                var cell = worksheet.Cells[headerRow, newIndex];
                cell.Value = header;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.Font.Bold = true;
                worksheet.Column(newIndex).AutoFit();
                worksheetHeadersIndex.AddOrUpdate(header, s => newIndex, (s, i1) => newIndex);
            }
        }

        private ConcurrentDictionary<string, int> worksheetHeadersIndex = new ConcurrentDictionary<string, int>();
        private ConcurrentDictionary<string, string> magicMapping;
        private string magicMappingFile;
        private DateTime? magicMappingFileLastRead;
    }

    public class SheetInfo
    {
        private bool changed;
        public string Key { get; set; }
        public DateTime Day { get; set; }
        public OrderDef KeyItem { get; set; }
        public double MaxDd { get; set; }
        public DateTime? MaxDdDate { get; set; }
        public double MaxEquity { get; set; }
        public DateTime? MaxEquityDate { get; set; }

        public bool Changed
        {
            get => changed;
            set
            {
                changed = value;
                if (value)
                    ChangedDate = DateTime.Now;
            }
        }

        public DateTime? ChangedDate { get; set; }

        public double ClosedProfit { get; set; }
    }

    class OrdersFiller
    {
        public bool IsHistory { get; set; }
        public OrdersLogger Parent { get; set; }

        internal readonly ConcurrentDictionary<int, OrderDef> ordersByTicket = new ConcurrentDictionary<int, OrderDef>();
        private readonly ConcurrentDictionary<int, OrderDef> fillingDictionary = new ConcurrentDictionary<int, OrderDef>();
        private int fillingCount;
        public bool Filling { get; private set; }
        public bool SetOrdersTotal(int count)
        {
            var res = Filling || fillingCount != count;
            Filling = true;
            fillingCount = count;
            fillingDictionary.Clear();
            if (count != 0)
                return res;
            FillingCompleted();
            return false;
        }


        public void SetOrderDef(int idx, string orderDefString)
        {
            var order = OrderDef.ConvertStringToOrderDef(orderDefString, ticketId => ordersByTicket.GetOrAdd(ticketId, i => new OrderDef()), () => Parent.TimeCurrent);
            fillingDictionary.AddOrUpdate(idx, i => order, (i, def) => order);
            if (idx == fillingCount - 1)
                FillingCompleted();
        }

        private void FillingCompleted()
        {
            var tickets = new HashSet<int>();
            var newOrders = fillingDictionary.ToList().OrderBy(x => x.Key).Select(x => x.Value).Where(x => tickets.Add(x.ticket)).ToList();
            if (newOrders.Count != fillingCount)
                return;
            Filling = false;
            Parent.FillingCompleted(newOrders, IsHistory);
        }
    }


}
