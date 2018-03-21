using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegiApi.Models.Smaregi
{
    public class ApiParams
    {
        [JsonProperty(PropertyName = "conditions", NullValueHandling = NullValueHandling.Ignore)]
        public ApiConditions Conditions { get; set; }

        [JsonProperty(PropertyName = "order", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Order { get; set; }

        [JsonProperty(PropertyName = "table_name", Required = Required.Always)]
        public string TableName { get; set; }
    }
}
