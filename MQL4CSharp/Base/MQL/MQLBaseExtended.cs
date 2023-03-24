using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.REST;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using MQL4CSharp.Base.MQL;
using MQL4CSharp.Util;
using Newtonsoft.Json;
using System.Runtime;

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
        public byte[] ChartGetTemplate(long chart_id)
        {
            var filename = GenerateFileName("templates", "tpl");
            try
            {
                var resBool = ChartSaveTemplate(chart_id, filename.Name);
                var res = File.ReadAllBytes(filename.FullName);
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

        #region Expert Advisor

        public override bool ChartSaveTemplate(long chart_id, string filename)
        {
            var res = base.ChartSaveTemplate(chart_id, filename);
            try
            {
                var fileInfo = GetFileInfo("templates", filename, "tpl");
                if (fileInfo.Exists)
                    SaveTemplateDataOnCache(0, File.ReadAllLines(fileInfo.FullName));
            }
            catch { /**/ }
            return res;
        }

        #region Gestione data in cache
        private string ExtractTemplateValue(IEnumerable<string> template, string key)
        {
            var item = template.FirstOrDefault(x => x.StartsWith($"{key}="));
            item = item == null ? null : item.Substring(key.Length + 1).Trim();
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
                var oldData = new { chart.EAEnabled, chart.EAName, chart.EASettings, chart.Symbol, chart.Period };
                FillChartModel(chart, template);
                if (oldData.EAEnabled != chart.EAEnabled || oldData.EAName != chart.EAName || oldData.EASettings != chart.EASettings ||
                    oldData.Symbol != chart.Symbol || oldData.Period != chart.Period)
                {
                    CacheStorageWrite();
                }
            }
            catch { }
        }

        private void FillChartModel(Mt4CharmModel chart, string[] template)
        {
            if (chart.Id == 0)
            {
                var id = ExtractTemplateValue(template.Take(10), "id");
                chart.Id = (id == null) ? 0 : Convert.ToInt64(id);
            }
            if (chart.Symbol == null)
                chart.Symbol = ExtractTemplateValue(template.Take(10), "symbol");
            chart.Period = ExtractTemplateValue(template.Take(10), "period");
            var expert = template.SkipWhile(s => s != "<expert>").Skip(1).TakeWhile(s => s != "</expert>").ToList();
            chart.EAEnabled = ExtractTemplateValue(expert, "flags") == "343";
            if (expert.Any())
            {
                chart.EAName = ExtractTemplateValue(expert, "name");
                chart.EASettings = template.SkipWhile(s => s != "<inputs>").Skip(1).TakeWhile(s => s != "</inputs>").Join("\r\n");
            }
        }

        private static string _cacheStorageFileName;
        private static DateTime? _cacheStorageWriteDate;
        private static CachedDataStorage _cacheStorage;
        private CachedDataStorage GetCacheStorage()
        {
            _cacheStorageFileName = _cacheStorageFileName ?? GetFileInfo("history", "mql4csharp.json").FullName;
            if (_cacheStorage == null && !File.Exists(_cacheStorageFileName))
            {
                _cacheStorage = new CachedDataStorage();
                CacheStorageWrite();
            }
            var lastWrite = File.GetLastWriteTime(_cacheStorageFileName);
            if (_cacheStorage == null || lastWrite > _cacheStorageWriteDate)
            {
                _cacheStorage = JsonConvert.DeserializeObject<CachedDataStorage>(File.ReadAllText(_cacheStorageFileName));
                _cacheStorageWriteDate = lastWrite;
            }
            return _cacheStorage;
        }
        private static object _lockObj = new object();
        private void CacheStorageWrite()
        {
            var settings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = JsonConvert.SerializeObject(_cacheStorage, settings);
            lock (_lockObj)
            {
                File.WriteAllText(_cacheStorageFileName, data);
                _cacheStorageWriteDate = File.GetLastWriteTime(_cacheStorageFileName);
            }
        }
        #endregion

        public string ChartExpertAdvisorName(long chart_id)
        {
            ChartGetTemplate(chart_id);
            var chart = GetCacheStorage().Charts.GetValueOrDefault(chart_id);
            return (chart?.EAEnabled == true ? chart.EAName : null) ?? "";
        }
        public string ChartExpertAdvisorLatestName(long chart_id)
        {
            ChartGetTemplate(chart_id);
            var chart = GetCacheStorage().Charts.GetValueOrDefault(chart_id);
            return chart?.EAName ?? "";
        }
        public string ChartExpertAdvisorLatestSettings(long chart_id)
        {
            ChartGetTemplate(chart_id);
            var chart = GetCacheStorage().Charts.GetValueOrDefault(chart_id);
            return chart?.EASettings ?? "";
        }

        public bool ChartExpertAdvisorDisable(long chart_id)
        {
            var template = "<chart>\r\n</chart>";
            var res = ChartApplyTemplate(chart_id, Encoding.UTF8.GetBytes(template));
            ChartExpertAdvisorNameWait(chart_id, "");
            return res;
        }

        public bool ChartExpertAdvisorEnableLatest(long chart_id)
        {
            var nameCurrent = ChartExpertAdvisorName(chart_id);
            if (!string.IsNullOrEmpty(nameCurrent))
                return true;
            var chart = GetCacheStorage().Charts.GetValueOrDefault(chart_id);
            if (string.IsNullOrEmpty(chart?.EAName))
                throw new Exception("Expert Advisor not saved in cache, can't activate without name!");
            return ChartExpertAdvisorEnablePrivate(chart_id, chart.EAName, chart.EASettings);
        }

        private bool ChartExpertAdvisorEnablePrivate(long chart_id, string expert_name, string expert_settings)
        {
            var template = $"<chart>\r\n<expert>\r\nname={expert_name}\r\nflags=343\r\nwindow_num=0\r\n<inputs>";
            if (expert_settings != null)
                template += $"\r\n{expert_settings}";
            template += "\r\n</inputs>\r\n</expert>\r\n</chart>";
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
