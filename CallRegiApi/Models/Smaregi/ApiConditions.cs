using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegiApi.Models.Smaregi
{
    public class ApiConditions : List<Dictionary<string, string>>
    {
        public void Add(string key, string value)
        {
            var dic = new Dictionary<string, string>()
            {
                { key, value }
            };
            Add(dic);
        }
    }
}
