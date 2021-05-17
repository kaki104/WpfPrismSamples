using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace PrismTab.ViewModels
{
    public class ConfirmControlViewModel : BindableBase, IDialogAware
    {
        public ICommand OkCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ConfirmControlViewModel()
        {
            OkCommand = new DelegateCommand(OnOk);
            CancelCommand = new DelegateCommand(OnCancel);
        }

        public event Action<IDialogResult> RequestClose;

        private void OnCancel()
        {
            RequestClose.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        private void OnOk()
        {
            RequestClose.Invoke(new DialogResult(ButtonResult.OK));
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            parameters.TryGetValue("id", out string id);
            parameters.TryGetValue("password", out string password);
            Debug.WriteLine($" id:{id}, password:{password}");

        }
    }
}
