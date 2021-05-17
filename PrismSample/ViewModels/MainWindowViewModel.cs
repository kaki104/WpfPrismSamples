using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismSample.Eventes;
using PrismSample.Views;
using System;
using System.Windows.Input;

namespace PrismSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand LoadedCommand { get; set; }

        private string _loginId;
        public string LoginId
        {
            get { return _loginId; }
            set { SetProperty(ref _loginId, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager,
            IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            LoadedCommand = new DelegateCommand(OnLoaded);
        }

        private void OnLoaded()
        {
            _eventAggregator.GetEvent<LoginEvent>()
                .Subscribe(ReceivedLogin, ThreadOption.UIThread, false, 
                filter => filter.LoginId.Length > 10);
            _regionManager.RegisterViewWithRegion("ContentRegion",
                typeof(LoginView));
        }

        private void ReceivedLogin(LoginEventArgs obj)
        {
            LoginId = obj.LoginId;
        }
    }
}
