using Prism.Ioc;
using Prism.Modularity;
using PrismTab.Views;
using System.Windows;

namespace PrismTab
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Menu1>();
            containerRegistry.RegisterForNavigation<Menu2>();

            containerRegistry.RegisterDialog<ConfirmControl>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            //return new ConfigurationModuleCatalog();
            return new DirectoryModuleCatalog
            {
                ModulePath = @".\\Modules"
            };
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<Module1.Module1Module>(
            //    InitializationMode.WhenAvailable);
            //moduleCatalog.AddModule<Module2.Module2Module>(
            //    InitializationMode.OnDemand);

        }
    }
}
