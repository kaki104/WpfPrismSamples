using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfSamples
{
    public class BindingWindowViewModel : BindableBase
    {
        private string _oneWay;

        public string OneWay
        {
            get { return _oneWay; }
            set 
            { 
                _oneWay = value;
                OnPropertyChanged(nameof(OneWay));
            }
        }

        private string _twoWay;

        public string TwoWay
        {
            get { return _twoWay; }
            set 
            { 
                _twoWay = value;
                OnPropertyChanged(nameof(TwoWay));
            }
        }

        private bool _oneWayToSource;

        public bool OneWayToSource
        {
            get { return _oneWayToSource; }
            set 
            { 
                _oneWayToSource = value;
                OnPropertyChanged(nameof(OneWayToSource));
            }
        }

        private string _codeBindingProperty;

        public string CodeBindingProperty
        {
            get { return _codeBindingProperty; }
            set 
            { 
                _codeBindingProperty = value;
                OnPropertyChanged(nameof(CodeBindingProperty));
            }
        }

        private IList<Person> _people;

        public IList<Person> People
        {
            get { return _people; }
            set 
            { 
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        public ICommand DeleteCommand { get; set; }

        private Person _selectedItem;

        public Person SelectedItem
        {
            get { return _selectedItem; }
            set 
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }


        public BindingWindowViewModel()
        {
            OneWay = "OneWay Binding";
            TwoWay = "TwoWay Binding";
            OneWayToSource = true;
            CodeBindingProperty = "Code Binidng ...";

            People = new ObservableCollection<Person> 
            {
                new Person{Id = 1, Name = "kaki104", Age = 11, HasMarried = true},
                new Person{Id = 2, Name = "kaki105", Age = 22, HasMarried = false},
                new Person{Id = 3, Name = "kaki106", Age = 33, HasMarried = true},
                new Person{Id = 4, Name = "kaki107", Age = 44, HasMarried = false},
                new Person{Id = 5, Name = "kaki108", Age = 55, HasMarried = true},
            };


            DeleteCommand = new DelegateCommand(OnDelete, obj => SelectedItem != null);

            PropertyChanged += BindingWindowViewModel_PropertyChanged;
        }

        private void BindingWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(SelectedItem):
                    ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged();
                    break;

            }
        }

        private void OnDelete(object obj)
        {
            if (SelectedItem == null) return;
            People.Remove(SelectedItem);
            Debug.WriteLine($"{People.Count}");
        }
    }
}
