using System.ComponentModel;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string _query;

        public string Query
        {
            get { return _query; }
            set
            {
                _query = value;
                OnPropertyChanged("Query");
            }
        }

        private CurrentConditions _currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return _currentConditions; }
            set
            {
                _currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City _selectedCity;

        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        public SearchCommand SearchCommand { get; set; }

        public WeatherViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City
                {
                    LocalizedName = "Kota"
                };

                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Sunny",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = 41
                        }
                    }

                };
            }

            SearchCommand = new SearchCommand(this);
        }
        
        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCitiesAsync(Query);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
