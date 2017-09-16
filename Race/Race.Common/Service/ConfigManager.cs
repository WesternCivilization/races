using System.Configuration;

namespace Race.Common.Service
{
    public class ConfigManager : IConfigManager
    {
        public string Read(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
