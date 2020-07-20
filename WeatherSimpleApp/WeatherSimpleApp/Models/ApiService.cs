using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherSimpleApp.Models
{
    //
    //THIS CLASS PROWIDES ONLY API CALLS!
    //
    class ApiService
    {
        HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient();
        }

        //API call funtions
        public async Task<ActualData> GetWeatherDataAsyncActual(string uri)
        {
            Console.WriteLine("Starting API Request");
            var data = new ActualData();
            try
            {
                Console.WriteLine("Sending API Request");
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Succes API Request");
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<ActualData>(content);
                }
                else
                {
                    Console.WriteLine($"ERROR --------------- {GlobalVariables.currentCountry}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail API Request");
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }
        public async Task<HourlyData> GetWeatherDataAsyncHourly(string uri)
        {

            var data = new HourlyData();

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<HourlyData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return data;
        }
        public async Task<DailyData> GetWeatherDataAsyncDaily(string uri)
        {

            var data = new DailyData();

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DailyData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return data;
        }
    }
    
}

