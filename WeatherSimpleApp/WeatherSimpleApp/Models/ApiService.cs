using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherSimpleApp.Models
{
    class ApiService
    {
        HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient();
        }

        public async Task<dynamic> GetWeatherDataAsync(string uri)
        {
            dynamic data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<dynamic>(content);
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
