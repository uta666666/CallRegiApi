using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegiApi.Models.Smaregi
{
    public class Account
    {
        private Account() { }

        public static Account Make()
        {
            var fInfo = new FileInfo("smaregiaccount.json");
            if (!fInfo.Exists)
            {
                try
                {
                    var account = new Account();
                    File.WriteAllText(fInfo.FullName, JsonConvert.SerializeObject(new Account()), Encoding.UTF8);
                }
                catch
                {
                }
                return null;
            }

            var json = File.ReadAllText(fInfo.FullName, Encoding.UTF8);
            try
            {
                return JsonConvert.DeserializeObject<Account>(json);
            }
            catch (JsonSerializationException)
            {
                return null;
            }
        }

        [JsonProperty(Required = Required.Always)]
        public string ContractId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Url { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string AccessToken { get; set; }
    }
}
