using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfSample2
{
    public class MainWindowViewModel : ObservableObject
    {
        private IList<Person> _people;
        public IList<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        public ICommand SelectionChangedCommand { get; set; }

        private Person _selectedItem;
        public Person SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

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

        public ICommand LoginCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public MainWindowViewModel()
        {
            People = new List<Person>
            {
                new Person{Id = 1, Name="홍길동1", Age=11, Sex=true},
                new Person{Id = 2, Name="홍길동2", Age=22, Sex=false},
                new Person{Id = 3, Name="홍길동3", Age=33, Sex=true},
                new Person{Id = 4, Name="홍길동4", Age=44, Sex=true},
                new Person{Id = 5, Name="홍길동5", Age=55, Sex=false},
                new Person{Id = 6, Name="홍길동6", Age=66, Sex=true},
                new Person{Id = 7, Name="홍길동7", Age=77, Sex=false},
                new Person{Id = 8, Name="홍길동8", Age=88, Sex=true},
                new Person{Id = 9, Name="홍길동9", Age=99, Sex=true},
                new Person{Id = 10, Name="홍길동10", Age=11, Sex=false}
            };

            SelectionChangedCommand = new RelayCommand<object>(OnSelectionChanged);

            LoginCommand = new RelayCommand(OnLogin, CanLogin);
            ExitCommand = new RelayCommand(OnExit);

            PropertyChanged += MainWindowViewModel_PropertyChanged;
        }

        private void OnExit()
        {
            App.Current.Shutdown();
        }

        private void MainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(Id):
                case nameof(Password):
                    ((RelayCommand)LoginCommand).NotifyCanExecuteChanged();
                    break;
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Id) 
                && !string.IsNullOrWhiteSpace(Password);
        }

        private void OnLogin()
        {
            MessageBox.Show("Login complete");
        }

        private void OnSelectionChanged(object obj)
        {
            var args = obj as SelectionChangedEventArgs;
            if (args == null) return;
            var item = args.AddedItems[0] as Person;
            if (item == null) return;
            SelectedItem = item;
        }
    }
}
