using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShoppingBird.Fly.Helpers
{
    public class DiskIOHelper
    {
        public string ReadConfigFile()
        {
            var configPath = GetConfigFilePath();
            return File.ReadAllText(configPath);
        }

        private string GetConfigFilePath()
        {
            return $"{AppDomain.CurrentDomain.BaseDirectory}\\Config.json";
        }
    }
}
