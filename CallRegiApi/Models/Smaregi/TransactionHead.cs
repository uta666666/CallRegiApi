using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegiApi.Models.Smaregi
{
    public class TransactionHead : ISmaregiEndpoint
    {
        public TransactionHead(ApiMethod apiMethods)
        {
            _api = apiMethods;
        }

        private ApiMethod _api;

        public async Task GetAsync(ApiConditions conditions = null, List<string> order = null)
        {
            var param = new ApiParams()
            {
                Conditions = conditions,
                Order = order,
                TableName = "TransactionHead"
            };
            var json = await _api.GetAsync("transaction_ref", param);
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            Data = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        public override string ToString()
        {
            return "TransactionHead";
        }

        public string Name { get { return ToString(); } }

        public string Data { get; private set; }
    }
}
