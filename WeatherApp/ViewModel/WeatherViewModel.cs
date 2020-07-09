using System.ComponentModel;

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
