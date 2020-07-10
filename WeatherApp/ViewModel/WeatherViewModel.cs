using System.ComponentModel;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel: INotifyPropertyChanged
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


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
