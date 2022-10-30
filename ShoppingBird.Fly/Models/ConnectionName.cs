using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    public class ConnectionName
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }

        [JsonProperty("Provider")]
        public string Provider { get; set; }
    }
}
