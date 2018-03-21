using CallRegiApi.Models.Smaregi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Reactive.Bindings;
using Livet;
using Livet.Messaging;

namespace CallRegiApi.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            CallSmaregiWindowCommand = new ReactiveCommand();
            CallSmaregiWindowCommand.Subscribe(() =>
            {
                var smaregiViewModel = new SmaregiMainViewModel();
                Messenger.Raise(new TransitionMessage("SmaregiWindowMessageKey"));
            });            
        }
        public ReactiveCommand CallSmaregiWindowCommand { get; }
    }
}
