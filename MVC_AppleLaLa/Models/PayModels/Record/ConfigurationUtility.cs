﻿using System.Configuration;

namespace MVC_AppleLaLa.Models.PayModels.Record
{
    public class ConfigurationUtility
    {
        /// <summary>
        /// 取得Web.config的AppSettings設定
        /// </summary>
        /// <param name="appSettingKey">讀取的appSettingKey</param>
        /// <returns></returns>
        public static string GetAppSetting(string appSettingKey)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings[appSettingKey]))
            {
                result = ConfigurationManager.AppSettings[appSettingKey].Trim();
            }

            return result;

        }

    }
}