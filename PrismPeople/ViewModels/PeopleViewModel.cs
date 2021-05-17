using Module1.Views;
using Module2.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismPeople.ViewModels
{
    public class PeopleViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public PeopleViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            _regionManager.RegisterViewWithRegion(
                "LeftRegion", typeof(PeopleList));

            _regionManager.RegisterViewWithRegion(
                "RightRegion", typeof(PeopleDetail));
        }
    }
}
