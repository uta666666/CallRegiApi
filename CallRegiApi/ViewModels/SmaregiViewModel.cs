using CallRegiApi.Models.Smaregi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Reactive.Bindings;

namespace CallRegiApi.ViewModels
{
    public class SmaregiMainViewModel
    {
        public SmaregiMainViewModel()
        {
            ApiAccount = Account.Make();
            if (ApiAccount != null)
            {
                MakeSmaregiEndpoints();
            }

            ApiResponse = new ReactiveProperty<string>();

            //Command
            CallSmaregiApiCommand = new ReactiveCommand<int>();
            CallSmaregiApiCommand.Subscribe(async i =>
            {
                if (i < 0) return;

                var endpoint = SmaregiEndpoints.Value[i];
                await endpoint.GetAsync();
                ApiResponse.Value = endpoint.Data;
            });

            RefreshAccountCommand = new ReactiveCommand();
            RefreshAccountCommand.Subscribe(() =>
            {
                MakeSmaregiEndpoints();
            });
        }

        private void MakeSmaregiEndpoints()
        {
            _smaregiApiMethod = new ApiMethod(ApiAccount.Url, ApiAccount.ContractId, ApiAccount.AccessToken);

            SmaregiEndpoints = SmaregiEndpoints ?? new ReactiveProperty<List<ISmaregiEndpoint>>();
            SmaregiEndpoints.Value = new List<ISmaregiEndpoint>()
            {
                new TransactionHead(_smaregiApiMethod)
            };
        }

        private ApiMethod _smaregiApiMethod;

        public ReactiveCommand<int> CallSmaregiApiCommand { get; }

        public ReactiveCommand RefreshAccountCommand { get; }

        public ReactiveProperty<List<ISmaregiEndpoint>> SmaregiEndpoints { get; private set; }

        public ReactiveProperty<string> ApiResponse { get; }

        public Account ApiAccount { get; }
    }
}
