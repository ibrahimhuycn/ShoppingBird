using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    public class ConfigModel
    {
        [JsonProperty("ConnectionName")]
        public List<ConnectionName> ConnectionName { get; set; }
    }
}
