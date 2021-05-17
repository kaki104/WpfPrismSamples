using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismSample.Eventes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrismSample.ViewModels
{
    public class LoginViewViewModel : BindableBase
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private readonly IEventAggregator _eventAggregator;

        public ICommand LoginCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public LoginViewViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;


            LoginCommand = new DelegateCommand(
                async () => await OnLoginAsync(), CanLogin)
                .ObservesProperty(() => Id)
                .ObservesProperty(() => Password)
                .ObservesProperty(() => IsWork);
            CancelCommand = new DelegateCommand(OnCancel)
                .ObservesCanExecute(() => BoolCancel);          
        }

        private bool _boolCancel;
        public bool BoolCancel
        {
            get { return _boolCancel; }
            set { SetProperty(ref _boolCancel, value); }
        }

        private bool _isWork;
        public bool IsWork
        {
            get { return _isWork; }
            set { SetProperty(ref _isWork, value); }
        }

        private bool CanCancel()
        {
            return !string.IsNullOrWhiteSpace(Id)
               && !string.IsNullOrWhiteSpace(Password);
        }

        private async void OnCancel()
        {
            await Task.Delay(1000);
            _eventAggregator.GetEvent<LoginEvent>()
            .Publish(new LoginEventArgs
            {
                LoginId = Id + "Cancel"
            });

        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Id)
                && !string.IsNullOrWhiteSpace(Password)
                && IsWork == false;
        }

        private async Task OnLoginAsync()
        {
            IsWork = true;
            BoolCancel = !BoolCancel;
            await Task.Delay(2000);
            MessageBox.Show("Login Complete");

            _eventAggregator.GetEvent<LoginEvent>()
                .Publish(new LoginEventArgs 
                {
                    LoginId = Id
                });

            IsWork = false;
        }
    }
}
