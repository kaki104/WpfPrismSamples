using Module2.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Module2
{
    public class Module2Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewB>();
        }
    }
}