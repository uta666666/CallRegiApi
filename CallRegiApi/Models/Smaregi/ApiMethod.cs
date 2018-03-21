using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CallRegiApi.Models.Smaregi
{
    public class ApiMethod
    {
        public ApiMethod(string baseUrl, string contractId, string accessToken)
        {
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("X_contract_id", contractId);
            _client.DefaultRequestHeaders.Add("X_access_token", accessToken);
        }

        private HttpClient _client = new HttpClient();

        public async Task<string> GetAsync(string procName, ApiParams param)
        {
            var paramJson = JsonConvert.SerializeObject(param);
            var transactionHead = await _client.PostAsync(string.Empty, new FormUrlEncodedContent(new Dictionary<string, string>() {
                { "proc_name", procName },
                { "params", paramJson}
            }));

            return await transactionHead.Content.ReadAsStringAsync();
        }
    }
}
