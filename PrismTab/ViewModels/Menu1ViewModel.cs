using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismTab.ViewModels
{
    public class Menu1ViewModel : BindableBase
    {
        private string _title;
        private readonly IDialogService _dialogService;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand ConfirmCommand { get; set; }

        public Menu1ViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            Title = "Menu1 Header";

            ConfirmCommand = new DelegateCommand(OnConfirm);
        }

        private void OnConfirm()
        {
            _dialogService.ShowDialog("ConfirmControl", 
                new DialogParameters($"id=test&password=test2"),
                results => 
                {
                    if (results.Result != ButtonResult.OK) return;
                    //OK
                });
        }
    }
}
