using System.Configuration;

namespace PlantillaWPF.Services
{
    public static class ConfigService
    {
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
} 