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
    class WeatherClient
    {
        ApiService AS;
        public  WeatherClient()
        {
            AS = new ApiService();
        }
        /// <summary>
        /// Returns actual weather for given city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>Returns actual weather for given city</returns>
        async public Task<ActualData> GetWeatherActual(string city)
        {
            ActualData _data = null;
            _data = await AS.GetWeatherDataAsyncActual(GenerateRequestUri(Constants.OpenWeatherMapEndpoint_actual, city));
            Console.WriteLine("Received data from API!");
            return _data;
        }
        /// <summary>
        /// Returns hourly weather for given city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>Returns hourly weather for given city</returns>
        async public Task<HourlyData> GetWeatherHourly(string city)
        {
            ActualData _data = null;
            _data = await AS.GetWeatherDataAsyncActual(GenerateRequestUri(Constants.OpenWeatherMapEndpoint_actual, city));
            if (_data == null) return null;
            HourlyData _datum = null;
            _datum = await AS.GetWeatherDataAsyncHourly(GenerateRequestUri(Constants.OpenWeatherMapEndpoint_all, _data.coord.lat.ToString(), _data.coord.lon.ToString(), "daily,minutely,current"));
            return _datum;
        }
        /// <summary>
        /// Returns daily weather for given city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>Returns daily weather for given city</returns>
        async public Task<DailyData> GetWeatherDaily(string city)
        {
            ActualData _data = null;
            _data = await AS.GetWeatherDataAsyncActual(GenerateRequestUri(Constants.OpenWeatherMapEndpoint_actual, city));
            if (_data == null) return null;
            DailyData _datum = null;
            _datum = await AS.GetWeatherDataAsyncDaily(GenerateRequestUri(Constants.OpenWeatherMapEndpoint_all, _data.coord.lat.ToString(), _data.coord.lon.ToString(), "minutely,current,hourly"));
            return _datum;
        }

        //Funtions to generate links to perform requests
        string GenerateRequestUri(string endpoint, string Cityname)
        {
            string requestUri = endpoint;
            Console.WriteLine(requestUri);
            requestUri += $"?q={Cityname}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            Console.WriteLine("test: " + requestUri);
            return requestUri;
        }
        string GenerateRequestUri(string endpoint, string lat, string lon, string excludings)
        {
            string requestUri = endpoint;
            requestUri += $"lat={lat}";
            requestUri += $"&lon={lon}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&exclude={excludings}";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            Console.WriteLine("test2: " + requestUri);
            return requestUri;
        }
    }

}
