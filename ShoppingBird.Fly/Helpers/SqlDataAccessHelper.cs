using Newtonsoft.Json;
using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBird.Fly.Helpers
{
    public class SqlDataAccessHelper
    {
        public string GetConnectionString(string name = "pShoppingBirdData")
        {
            //return "Server=DESKTOP-SMO1O2S\\SQLSERVERCI;Database=ShoppingBird.Data;User Id=sa;Password=Bismillah.123!;TrustServerCertificate=true;";
            return ReadConnectionString(name);
        }

        private string ReadConnectionString(string name)
        {
            var reader = new DiskIOHelper();
            var config = JsonConvert.DeserializeObject<ConfigModel>(reader.ReadConfigFile());
            if (config is null) { throw new Exception("Cannot read config file."); }

            var configData = config.ConnectionName.Where(x => x.Name == name).FirstOrDefault();
            if (configData is null) { throw new Exception($"Cannot find the specified connection [{name}]"); }

            return configData.ConnectionString;
        }
    }
}
