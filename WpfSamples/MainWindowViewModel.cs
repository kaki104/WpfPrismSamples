namespace WpfSamples
{
    public class MainWindowViewModel : BindableBase
    {
        private string _hello;

        public string Hello 
        { 
            get => _hello;
            set 
            { 
                if ( _hello != value)
                {
                    _hello = value;
                    OnPropertyChanged(nameof(Hello));
                }
            }  
        }

        public MainWindowViewModel()
        {
            Hello = "Hello MVVM Pattern World";
        }
    }
}
