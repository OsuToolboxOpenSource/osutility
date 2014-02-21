using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OsuService.LocalService
{
    public class ConfigCore
    {
        /// <summary>
        /// 读取一个配置
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public string GetSoloValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 修改一个配置
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public void ReviseSoloValue(string key, string value)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //修改
            string aaaaa = cfa.FilePath;  //配置文件的物理路径
            cfa.AppSettings.Settings[key].Value = value;
            cfa.Save();
        }

        /// <summary>
        /// 添加一个配置
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public void AddSoloValue(string key, string value)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //添加
            cfa.AppSettings.Settings.Add(key, value);
            cfa.Save();
        }

        // Create the AppSettings section.
        // The function uses the GetSection(string)method 
        // to access the configuration section. 
        // It also adds a new element to the section collection.
        private void CreateAppSettings()
        {
            // Get the application configuration file.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string sectionName = "appSettings";

            // Add an entry to appSettings.
            int appStgCnt = ConfigurationManager.AppSettings.Count;
            string newKey = "NewKey" + appStgCnt.ToString();

            string newValue = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();

            config.AppSettings.Settings.Add(newKey, newValue);

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of the changed section. This 
            // makes the new values available for reading.
            ConfigurationManager.RefreshSection(sectionName);

            // Get the AppSettings section.
            AppSettingsSection appSettingSection = (AppSettingsSection)config.GetSection(sectionName);

            Console.WriteLine();
            Console.WriteLine("Using GetSection(string).");
            Console.WriteLine("AppSettings section:");
            Console.WriteLine(appSettingSection.SectionInformation.GetRawXml());
        }
    }
}
