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
        /// Returns actual data about weather at passed city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>Returns actual data about weather at passed city</returns>
        async public Task<dynamic> GetWeather(string city)
        {
            dynamic _data = null;
            _data = await AS.GetWeatherDataAsync(GenerateRequestUri(Constants.OpenWeatherMapEndpoint_actual, city));
            return _data;
        }
        /// <summary>
        /// Returns weather for specifed range for passed city
        /// </summary>
        /// <param name="city">City name</param>
        /// <param name="range">range can be equal to "actual", "minutely", "hourly" or "daily"</param>
        /// <returns>Returns weather for specifed range for passed city</returns>
        async public Task<dynamic> GetWeather(string city , string range)
        {
            dynamic _data = null;
            _data = await AS.GetWeatherDataAsync(GenerateRequestUri(Constants.OpenWeatherMapEndpoint_actual, city));
            switch (range)
            {
                case "actual":
                    {
                        //todo
                        break;
                    }
                default:
                    {
                        string returns = "Range value is invaild";
                        return returns;
                        
                    }
            }

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
        }string GenerateRequestUri(string endpoint, string lat, string lon, string excludings)
        {
            string requestUri = endpoint;
            requestUri += $"lat={lat}";
            requestUri += $"&lon={lon}";
            requestUri += $"&exclude={excludings}";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            Console.WriteLine(requestUri);
            return requestUri;
        }
    }

}
