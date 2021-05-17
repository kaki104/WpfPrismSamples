using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismModels;
using PrismModels.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Module1.ViewModels
{
    public class PeopleListViewModel : BindableBase
    {
        private IList<Person> _people;
        private readonly IEventAggregator _eventAggregator;

        public IList<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set 
            { 
                SetProperty(ref _selectedPerson, value, 
                    () => 
                    {
                        _eventAggregator.GetEvent<PersonChangedEvnet>()
                            .Publish(new PersonChangedEventArgs
                            {
                                ChangedPerson = SelectedPerson
                            });
                    }); 
            }
        }

        public PeopleListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            People = new ObservableCollection<Person> 
            {
                new Person{Id=1, Name = "홍길동1", Age = 11},
                new Person{Id=2, Name = "홍길동2", Age = 12},
                new Person{Id=3, Name = "홍길동3", Age = 13},
                new Person{Id=4, Name = "홍길동4", Age = 14},
                new Person{Id=5, Name = "홍길동5", Age = 15},
                new Person{Id=6, Name = "홍길동6", Age = 16},
                new Person{Id=7, Name = "홍길동7", Age = 17},
            };

        }

    }
}
