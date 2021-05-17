using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismModels;
using PrismModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module2.ViewModels
{
    public class PeopleDetailViewModel : BindableBase
    {
        private Person _currentPerson;
        private readonly IEventAggregator _eventAggregator;

        public Person CurrentPerson
        {
            get { return _currentPerson; }
            set { SetProperty(ref _currentPerson, value); }
        }

        public PeopleDetailViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            CurrentPerson = new Person { Id = 1, Name = "홍씨", Age = 99 };

            _eventAggregator.GetEvent<PersonChangedEvnet>()
                .Subscribe(ReceivedPersonChanged);
        }

        private void ReceivedPersonChanged(PersonChangedEventArgs obj)
        {
            CurrentPerson = obj.ChangedPerson;
        }
    }
}
