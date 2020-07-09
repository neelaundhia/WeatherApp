using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        public const string BaseURL = "http://dataservice.accuweather.com/";
        public const string APIKey = "4exuHrTZQKAalPDjNY1Og2JrdhCxQQS6";

        //{0}: APIKey Eg. 4exuHrTZQKAalPDjNY1Og2JrdhCxQQS6
        //{1}: Search Query Eg. Kota
        public const string AutoCompleteEndPoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";

        //{0}: City Key Eg. 190216 (for Kota, Rajasthan)
        //{1}: APIKey Eg. 4exuHrTZQKAalPDjNY1Og2JrdhCxQQS6
        public const string CurrentConditionsEndpoint = "currentconditions/v1/{0}?apikey={1}";

        public static async Task<List<City>> GetCitiesAsync(string query)
        {
            List<City> cities = new List<City>();

            string url = BaseURL + String.Format(AutoCompleteEndPoint, APIKey, query);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string responseJson = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(responseJson);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditionsAsync(string cityKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();

            string url = BaseURL + String.Format(AutoCompleteEndPoint, cityKey, APIKey);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string responseJson = await response.Content.ReadAsStringAsync();

                currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(responseJson)).FirstOrDefault();
            }

            return currentConditions;
        }
    }
}
