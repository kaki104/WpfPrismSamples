using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace PrismTab.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IRegionManager _regionManager;
        private readonly IModuleManager _moduleManager;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand MenuCommand { get; set; }

        public ICommand LoadModuleCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager, 
            IModuleManager moduleManager)
        {
            _regionManager = regionManager;
            _moduleManager = moduleManager;

            MenuCommand = new DelegateCommand<string>(OnMenu);
            LoadModuleCommand = new DelegateCommand(OnLoadModule);
        }

        private void OnLoadModule()
        {
            _moduleManager.LoadModuleCompleted += _moduleManager_LoadModuleCompleted;
            _moduleManager.LoadModule("Module2Module");
        }

        private void _moduleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            _moduleManager.LoadModuleCompleted -= _moduleManager_LoadModuleCompleted;
            MessageBox.Show("LoadModule Completed");
        }

        private void OnMenu(string obj)
        {
            _regionManager.RequestNavigate("ContentRegion", obj, 
                callback => 
                {
                    if (callback.Error == null) return;
                    _moduleManager.LoadModule("Module2Module");
                    OnMenu(obj);
                });
        }
    }
}
