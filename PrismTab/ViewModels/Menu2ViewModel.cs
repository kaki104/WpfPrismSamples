using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismTab.ViewModels
{
    public class Menu2ViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public Menu2ViewModel()
        {
            Title = "Menu2 Header";
        }
    }
}
