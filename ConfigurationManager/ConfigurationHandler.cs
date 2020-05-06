using System;
using Microsoft.Extensions.Configuration;

namespace ConfigurationManager
{
    public class ConfigurationHandler
    {
        private readonly IConfiguration theConfig;
        private string generalSettingsLabel = "GeneralSettings";
        private string text1Label = "Text1";

        public ConfigurationHandler(IConfiguration configuration)
        {
            theConfig = configuration;
        }

        public T GetGeneralSettings<T>(string settingName) where T : IConvertible
        {
            return ReadSettings<T>(generalSettingsLabel, settingName);
        }

        private T ReadSettings<T>(string path, string key) where T : IConvertible
        {
            T s = theConfig.GetValue<T>($"{path}:{key}");
            return s;
        }
    }
}
