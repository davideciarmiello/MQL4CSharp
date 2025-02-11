﻿using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.REST;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using MQL4CSharp.Base.MQL;
using MQL4CSharp.Util;
using Newtonsoft.Json;
using System.Runtime;
using MQL4CSharp.UserDefined.Input;
using System.Xml.Linq;
using MQL4CSharp.Base.Exceptions;

namespace MQL4CSharp.Base
{
    /// <summary>
    /// Class with methods customized of standard methods
    /// </summary>
    public abstract class MQLBaseExtended : MQLBase
    {
        protected MQLBaseExtended(long ix) : base(ix)
        {
        }

        internal int _lastAccountNumber;
        /// <summary>
        /// Function: AccountNumber
        /// Description: Returns the current account number.
        /// URL: http://docs.mql4.com/account/accountnumber
        /// </summary>
        public override int AccountNumber()
        {
            var res = base.AccountNumber();
            if (res == _lastAccountNumber)
                return res;
            _lastAccountNumber = res;
            try { InitStorageInfo(res); }
            catch { /**/ }
            return res;
        }

        internal void InitStorageInfo()
        {
            try
            {
                if (string.IsNullOrEmpty(CachedDataStorageInstance.TerminalDataPath))
                    CachedDataStorageInstance.TerminalDataPath = TerminalInfoString((int)TERMINAL_INFO_STRING.TERMINAL_DATA_PATH);
            }
            catch { /**/ }
            try
            {
                var accountNumber = base.AccountNumber();
                InitStorageInfo(accountNumber);
                _lastAccountNumber = accountNumber;
                InitFileWatcher();
            }
            catch { /**/}
        }

        protected virtual void InitStorageInfo(int accountNumber)
        {
            var storage = GetCacheStorage();
            var changed = false;
            if (storage.TerminalPath == null)
            {
                storage.TerminalPath = TerminalInfoString((int)TERMINAL_INFO_STRING.TERMINAL_PATH);
                changed = true;
            }
            using (var p = Process.GetCurrentProcess())
            {
                if (p.Id != storage.TerminalPID)
                {
                    storage.TerminalPID = p.Id;
                    changed = true;
                }
            }
            if (storage.AccountNumber != accountNumber)
            {
                storage.AccountNumber = accountNumber > 0 ? accountNumber : (int?)null;
                storage.AccountName = accountNumber > 0 ? AccountName() : null;
                storage.AccountServer = accountNumber > 0 ? AccountServer() : null;
                changed = true;
            }
            if (changed)
                CacheStorageWrite();
        }

        /// <summary>
        /// Function: ChartApplyTemplate
        /// Description: Applies a specific template from a specified file to the chart. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://docs.mql4.com/chart_operations/chartapplytemplate
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="filecontent">[in] The content of the file containing the template in base64.</param>
        public bool ChartApplyTemplate(long chart_id, byte[] filecontent)
        {
            var filename = GenerateFileName("templates", "tpl");
            File.WriteAllBytes(filename.FullName, filecontent);
            try
            {
                return ChartApplyTemplate(chart_id, filename.Name);
            }
            finally
            {
                DeleteFile(10, filename.FullName, TimeSpan.FromSeconds(30), false);
            }
        }

        private Mt4CharmModel ChartModelLoadAndGet(long chart_id, bool requiredActive)
        {
            try
            {
                ChartGetTemplatePrivate(chart_id, true, onlyFromFileChr: requiredActive == false);
            }
            catch
            {
                if (requiredActive)
                    throw;
            }
            var chart = GetCacheStorage().Charts.GetValueOrDefault(chart_id);
            if (chart == null)
                throw new ChartNotFoundException($"ChartId: {chart_id}");
            return chart;
        }

        private object lockObj = new object();
        private FileSystemWatcher fileSystemWatcher;
        private void InitFileWatcher()
        {
            if (fileSystemWatcher != null)
                return;
            var chartDir = new DirectoryInfo(Path.Combine(CachedDataStorageInstance.GetTerminalDataPath(), "profiles\\default"));
            if (chartDir.Exists != true)
                return;
            var watcher = new FileSystemWatcher();
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastWrite;
            watcher.Path = chartDir.FullName;
            watcher.Filter = "*.chr";
            var dict = new ConcurrentDictionary<string, DateTime>();
            watcher.Changed += (sender, args) =>
            {
                lock (lockObj)
                {
                    try
                    {
                        Thread.Sleep(50);
                        var fileDate = File.GetLastWriteTimeUtc(args.FullPath);
                        if (dict.GetValueOrDefault(args.FullPath) == fileDate)
                            return;
                        dict.AddOrUpdate(args.FullPath, s => fileDate, (s, time) => fileDate);
                        var template = File.ReadAllLines(args.FullPath);
                        var id = ExtractTemplateValue(template.Take(10), "id");
                        if (id == null)
                            return;
                        var chartid = Convert.ToInt64(id);
                        var isMine = GetCacheStorage().Charts?.ContainsKey(chartid) == true;
                        if (!isMine && !string.IsNullOrEmpty(ChartSymbol(chartid)))
                            isMine = true;
                        if (isMine)
                            SaveTemplateDataOnCache(chartid, template);
                    }
                    catch {/**/}
                }
            };
            fileSystemWatcher = watcher;
            watcher.EnableRaisingEvents = true;
        }

        public byte[] ChartGetTemplate(long chart_id)
        {
            return ChartGetTemplatePrivate(chart_id, false);
        }
        private byte[] ChartGetTemplatePrivate(long chart_id, bool returnNull = false, bool onlyFromFileChr = false)
        {
            var chartDir = new DirectoryInfo(Path.Combine(CachedDataStorageInstance.GetTerminalDataPath(), "profiles\\default"));
            if (chartDir.Exists)
            {
                InitFileWatcher();
                foreach (var fileInfo in chartDir.GetFiles("*.chr"))
                {
                    try
                    {
                        var template = File.ReadAllLines(fileInfo.FullName);
                        if (!template.Contains($"id={chart_id}"))
                            continue;
                        SaveTemplateDataOnCache(chart_id, template);
                        var res = returnNull ? null : File.ReadAllBytes(fileInfo.FullName);
                        return res;
                    }
                    catch {/**/}
                }
                if (onlyFromFileChr)
                    return null;
            }
            var filename = GenerateFileName("templates", "tpl");
            try
            {
                var resBool = ChartSaveTemplate(chart_id, filename.Name);
                var res = returnNull ? null : File.ReadAllBytes(filename.FullName);
                return res;
            }
            finally
            {
                DeleteFile(10, filename.FullName, TimeSpan.FromSeconds(30), true);
            }
        }
        public byte[] ChartScreenShot(long chart_id, int width, int height, ALIGN_MODE align_mode)
        {
            var filename = GenerateFileName("MQL4\\Files", "png");
            try
            {
                var resBool = ChartScreenShot(chart_id, filename.Name, width, height, align_mode);
                var res = File.ReadAllBytes(filename.FullName);
                return res;
            }
            finally
            {
                DeleteFile(10, filename.FullName, TimeSpan.FromSeconds(30), true);
            }
        }

        public bool OrderClose(int ticket, int slippage)
        {
            if (!OrderSelect(ticket, (int)SELECTION_TYPE.SELECT_BY_TICKET, (int)SELECTION_POOL.MODE_TRADES))
                return false;
            var symbol = OrderSymbol();
            var orderType = OrderType();
            if (orderType == (int)TRADE_OPERATION.OP_BUY)
            {
                return OrderClose(ticket, OrderLots(), SymbolInfoPrice(symbol, false), slippage, COLOR.Red);
            }
            if (orderType == (int)TRADE_OPERATION.OP_SELL)
            {
                return OrderClose(ticket, OrderLots(), SymbolInfoPrice(symbol, true), slippage, COLOR.Red);
            }
            return false;
        }

        /// <summary>
        /// Returns the corresponding string of current order
        /// </summary>
        /// <returns></returns>
        public string OrderGetOrderDefString()
        {
            List<Object> parameters = new List<Object>();
            return (string)ExecCommand(MQLCommand.OrderGetOrderDefString_1, parameters);
        }

        private ConcurrentDictionary<int, OrderDef> orderDefCache = new ConcurrentDictionary<int, OrderDef>();
        /// <summary>
        /// Returns the corresponding string of current order
        /// </summary>
        /// <returns></returns>
        public OrderDef OrderGetOrderDefModel()
        {
            var str = OrderGetOrderDefString();
            var model = OrderDef.ConvertStringToOrderDef(str, i => i > 0 ? orderDefCache.GetOrAdd(i, i1 => new OrderDef()) : new OrderDef());
            return model;
        }


        #region Expert Advisor

        /// <summary>
        /// Function: ChartSaveTemplate
        /// Description: Saves current chart settings in a template with a specified name. The command is added to chart message queue and executed only after all previous commands have been processed.
        /// URL: http://docs.mql4.com/chart_operations/chartsavetemplate
        /// </summary>
        /// <param name="chart_id">[in] Chart ID. 0 means the current chart.</param>
        /// <param name="filename">[in] The filename to save the template. The ".tpl" extension will be added to the filename automatically; there is no need to specify it. The template is saved in terminal_directory\Profiles\Templates\ and can be used for manual application in the terminal. If a template with the same filename already exists, the contents of this file will be overwritten.</param>
        public override bool ChartSaveTemplate(long chart_id, string filename)
        {
            var res = base.ChartSaveTemplate(chart_id, filename);
            try
            {
                var fileInfo = GetFileInfo("templates", filename, "tpl");
                if (fileInfo.Exists && res)
                    SaveTemplateDataOnCache(chart_id, File.ReadAllLines(fileInfo.FullName));
            }
            catch { /**/ }
            return res;
        }

        #region Gestione data in cache
        private string ExtractTemplateValue(IEnumerable<string> template, string key)
        {
            key = $"{key}=";
            var item = template.FirstOrDefault(x => x.StartsWith(key));
            item = item?.Substring(key.Length).Trim();
            return item == "" ? null : item;
        }
        private void SaveTemplateDataOnCache(long chart_id, string[] template)
        {
            try
            {
                if (chart_id == 0)
                {
                    var id = ExtractTemplateValue(template.Take(10), "id");
                    if (id == null)
                        return;
                    chart_id = Convert.ToInt64(id);
                }
                var storage = GetCacheStorage();
                storage.Charts = storage.Charts ?? new ConcurrentDictionary<long, Mt4CharmModel>();
                var chart = storage.Charts.GetOrAdd(chart_id, l => new Mt4CharmModel() { Id = chart_id });
                Func<Mt4CharmModel, string> chartKey = m => $"{m.Symbol}|{m.Period}|{m.EAEnabled}|{m.EAEnabledFlags}|{m.EAName}|{m.EASettings}|";
                var oldData = chartKey(chart);
                FillChartModel(chart, template);
                if (oldData != chartKey(chart))
                {
                    CacheStorageWrite();
                }
            }
            catch { }
        }

        private void FillChartModel(Mt4CharmModel chart, string[] template)
        {
            chart.CurrentTemplateContent = template;

            if (chart.Id == 0)
            {
                var id = ExtractTemplateValue(template.Take(10), "id");
                chart.Id = (id == null) ? 0 : Convert.ToInt64(id);
            }
            if (chart.Symbol == null)
                chart.Symbol = ExtractTemplateValue(template.Take(10), "symbol");
            chart.Period = ExtractTemplateValue(template.Take(10), "period") ?? chart.Period;

            var expert = ExtractExpertFromTemplate(template);
            var flag = ExtractTemplateValue(expert, "flags");
            chart.EAEnabled = new[] { "343", "342", "341", "855", "279", "23" }.Contains(flag ?? "");
            if (chart.EAEnabled)
                chart.EAEnabledFlags = flag;
            if (expert.Any())
            {
                chart.EAName = ExtractTemplateValue(expert, "name");
                chart.EASettings = expert.SkipWhile(s => s != "<inputs>").Skip(1).TakeWhile(s => s != "</inputs>").Join("\r\n");
            }
        }

        private static List<string> ExtractExpertFromTemplate(string[] template)
        {
            var lstFullPath = new List<string>();
            var templateWithFullPath = template
                .Select((x, i) =>
                {
                    var retStr = x;
                    if (x.StartsWith("</"))
                    {
                        var key = x.Trim('<', '/', '>');
                        if (lstFullPath.LastOrDefault() == key)
                        {
                            retStr = $"</{lstFullPath.Join("_")}>";
                            lstFullPath.RemoveAt(lstFullPath.Count - 1);
                        }
                    }
                    else if (x.StartsWith("<"))
                    {
                        var key = x.Trim('<', '/', '>');
                        lstFullPath.Add(key);
                        retStr = $"<{lstFullPath.Join("_")}>";
                    }
                    return retStr;
                })
                .ToList();
            lstFullPath.Clear();

            var idxBegin = templateWithFullPath.LastIndexOf("<chart_expert>");
            var idxEnd = templateWithFullPath.IndexOf("</chart_expert>", idxBegin + 1);
            if (idxBegin <= -1 || idxEnd <= -1)
                return new List<string>();
            var lst = template.Take(idxEnd + 1).Skip(idxBegin).ToList();
            return lst;
        }

        private CachedDataStorage GetCacheStorage()
        {
            if (string.IsNullOrEmpty(CachedDataStorageInstance.TerminalDataPath))
                try { CachedDataStorageInstance.TerminalDataPath = TerminalInfoString((int)TERMINAL_INFO_STRING.TERMINAL_DATA_PATH); }
                catch { /**/ }
            var instance = CachedDataStorageInstance.GetCacheStorage();
            return instance;
        }

        private void CacheStorageWrite()
        {
            CachedDataStorageInstance.CacheStorageWrite();
        }

        #endregion

        public string ChartExpertAdvisorLastActiveName(long chart_id)
        {
            var chart = ChartModelLoadAndGet(chart_id, false);
            return chart?.EAName ?? "";
        }
        public string ChartExpertAdvisorLastActiveSettings(long chart_id)
        {
            var chart = ChartModelLoadAndGet(chart_id, false);
            return chart?.EASettings ?? "";
        }
        public bool ChartExpertAdvisorEnableLastActive(long chart_id)
        {
            var nameCurrent = ChartExpertAdvisorName(chart_id);
            if (!string.IsNullOrEmpty(nameCurrent))
                return true;
            var chart = GetCacheStorage().Charts.GetValueOrDefault(chart_id);
            if (string.IsNullOrEmpty(chart?.EAName))
                throw new Exception("Expert Advisor not saved in cache, can't activate without name!");
            return ChartExpertAdvisorEnablePrivate(chart_id, chart.EAName, chart.EASettings);
        }

        public string ChartExpertAdvisorName(long chart_id)
        {
            var chart = ChartModelLoadAndGet(chart_id, false);
            return (chart?.EAEnabled == true ? chart.EAName : null) ?? "";
        }

        public bool ChartExpertAdvisorDisable(long chart_id)
        {
            //call ChartExpertAdvisorName, that store a actual ExpertAdvisor in cache
            if (string.IsNullOrEmpty(ChartExpertAdvisorName(chart_id)))
                return true;
            var chart = ChartModelLoadAndGet(chart_id, true);
            var expert = ExtractExpertFromTemplate(chart.CurrentTemplateContent).Join("\r\n");
            var chartContent = chart.CurrentTemplateContent.Join("\r\n");
            var template = chartContent.Replace(expert, "");
            var res = ChartApplyTemplate(chart_id, Encoding.UTF8.GetBytes(template));
            ChartExpertAdvisorNameWait(chart_id, "");
            return res;
        }


        private bool ChartExpertAdvisorEnablePrivate(long chart_id, string expert_name, string expert_settings)
        {
            var chart = ChartModelLoadAndGet(chart_id, true);
            var oldExpert = ExtractExpertFromTemplate(chart.CurrentTemplateContent).Join("\r\n");
            var chartContent = chart.CurrentTemplateContent.Join("\r\n");

            if (string.IsNullOrEmpty(chart.EAEnabledFlags))
                chart.EAEnabledFlags = "855";
            var newExpert = $"<expert>\r\nname={expert_name}\r\nflags={chart.EAEnabledFlags}\r\nwindow_num=0\r\n<inputs>";
            if (expert_settings != null)
                newExpert += $"\r\n{expert_settings}";
            newExpert += "\r\n</inputs>\r\n</expert>";

            var template = chartContent;
            template = !string.IsNullOrEmpty(oldExpert) ? template.Replace(oldExpert, newExpert) : template.Replace("</chart>", $"{newExpert}\r\n</chart>");
            var res = ChartApplyTemplate(chart_id, Encoding.UTF8.GetBytes(template));
            ChartExpertAdvisorNameWait(chart_id, expert_name);
            return res;
        }
        public bool ChartExpertAdvisorEnable(long chart_id, string expert_name, byte[] preset_filecontent)
        {
            return ChartExpertAdvisorEnablePrivate(chart_id, expert_name, preset_filecontent == null ? null : Encoding.Default.GetString(preset_filecontent).Trim());
        }

        public bool ChartExpertAdvisorEnable(long chart_id, string expert_name, string preset_filename)
        {
            var fileInfo = preset_filename != null ? GetFileInfo("Presets", preset_filename, "set") : null;
            return ChartExpertAdvisorEnablePrivate(chart_id, expert_name, fileInfo != null ? File.ReadAllText(fileInfo.FullName) : null);
        }


        private void ChartExpertAdvisorNameWait(long chart_id, string expert_name)
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    if ((ChartExpertAdvisorName(chart_id) ?? "") == expert_name)
                        break;
                    Thread.Sleep(50);
                }
            }
            catch
            {
            }
        }

        #endregion

        public byte[] FileRead(string filename)
        {
            var fileInfo = GetFileInfo(null, filename);
            var res = File.ReadAllBytes(fileInfo.FullName);
            return res;
        }
        public bool FileWrite(string filename, byte[] filecontent)
        {
            var fileInfo = GetFileInfo(null, filename);
            File.WriteAllBytes(fileInfo.FullName, filecontent);
            return true;
        }
        public bool FileDelete(string filename)
        {
            var fileInfo = GetFileInfo(null, filename);
            return DeleteFile(5, fileInfo.FullName, TimeSpan.FromSeconds(5), true);
        }

        #region gestione files
        protected FileInfo GenerateFileName(string directory, string fileExtension)
        {
            var fileName = $"tmp_{Guid.NewGuid().ToString().Replace("-", "")}.{fileExtension}";
            return GetFileInfo(directory, fileName);
        }

        private string terminalDataPath;
        protected FileInfo GetFileInfo(string directory, string fileName, string extension = null)
        {
            if (Path.IsPathRooted(fileName))
                return new FileInfo(fileName);
            var dataPath = terminalDataPath ?? (terminalDataPath = TerminalInfoString((int)TERMINAL_INFO_STRING.TERMINAL_DATA_PATH));
            if (string.IsNullOrEmpty(CachedDataStorageInstance.TerminalDataPath))
                CachedDataStorageInstance.TerminalDataPath = dataPath;
            var fileInfo = new FileInfo(Path.Combine(dataPath, fileName.StartsWith($"{directory}\\") ? "." : directory ?? ".", fileName));
            if (!fileInfo.Exists && extension != null && !fileName.EndsWith(extension))
                fileInfo = new FileInfo($"{fileInfo.FullName}.{extension}");
            return fileInfo;
        }
        private bool DeleteFile(int tentativi, string fileName, TimeSpan delay, bool delayIfFirstFailed)
        {
            if (delay != TimeSpan.Zero && !delayIfFirstFailed)
            {
                new Task(() =>
                {
                    Thread.Sleep(delay);
                    DeleteFile(tentativi, fileName, TimeSpan.Zero, false);
                }).Start();
                return false;
            }
            for (int i = 0; i < tentativi; i++)
            {
                try
                {
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                    return true;
                }
                catch
                {
                    if (i == 0 && delayIfFirstFailed)
                    {
                        return DeleteFile(tentativi, fileName, delay, false);
                    }
                    Thread.Sleep(50);
                }
            }
            return false;
        }

        #endregion
    }
}
