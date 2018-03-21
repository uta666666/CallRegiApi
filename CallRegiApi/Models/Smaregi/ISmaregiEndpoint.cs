using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRegiApi.Models.Smaregi
{
    public interface ISmaregiEndpoint
    {
        Task GetAsync(ApiConditions conditions = null, List<string> order = null);

        string ToString();

        string Name { get; }

        string Data { get; }
    }
}
