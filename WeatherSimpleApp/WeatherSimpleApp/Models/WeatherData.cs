using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WeatherSimpleApp.Models
{
    class WeatherData
    {
        ApiService AS;
        public WeatherData()
        {
            AS = new ApiService();
        }
        /// <summary>
        /// Pass city name to receive actual data about weather that city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>Informations about actual weather in passed city</returns>
        async public Task<dynamic> GetActualWeather(string city)
        {
            dynamic _data = null;
            _data = await AS.GetWeatherDataAsync(GenerateRequestUri(Constants.OpenWeatherMapEndpoint_actual, city));
            return _data;
        }
        string GenerateRequestUri(string endpoint, string Cityname)
        {
            string requestUri = endpoint;
            requestUri += $"?q={Cityname}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            Console.WriteLine(requestUri);
            return requestUri;
        }
    }

}
