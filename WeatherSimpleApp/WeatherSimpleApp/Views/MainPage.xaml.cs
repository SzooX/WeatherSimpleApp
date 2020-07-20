using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using WeatherSimpleApp.Models;
namespace WeatherSimpleApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static MainPage Instance;
        WeatherClient wc = new WeatherClient();
        public MainPage()
        {
            if (Instance == null) Instance = this;

            InitializeComponent();

            if (string.IsNullOrEmpty(GlobalVariables.currentCountry))
            {
                EnableNoCountryView();
            }
            else
            {
                EnableCountryView();
            }
           
        }
        //Example methods of receiving data about weather
        async public void testmethod()
        {
            ActualData data = await wc.GetWeatherActual("Kraków");
        }
        async public void testmethod2()
        {
            HourlyData data = await wc.GetWeatherHourly("Kraków");
        }
        async public void testmethod3()
        {
            DailyData data = await wc.GetWeatherDaily("Kraków");
            TimeConverter.UnixTimeStampToDateTime(data.daily[0].sunrise, data.timezone);
        }

        public void EnableNoCountryView()
        {
            NoCountryLabel.IsVisible = true;
            TemperatureBox.IsVisible = false;
            ConditionsBox.IsVisible = false;
            WindBox.IsVisible = false;
        }

        public void EnableCountryView()
        {
            NoCountryLabel.IsVisible = false;
            TemperatureBox.IsVisible = true;
            ConditionsBox.IsVisible = true;
            WindBox.IsVisible = true;
        }

        public async void UpdateWeather()
        {
            ActualData data = await wc.GetWeatherActual(GlobalVariables.currentCountry);
            Temperature_now.Text = data.main.temp + "55&#186;C";
            Temperature_min.Text = data.main.temp_min + "55&#186;C";
            Temperature_max.Text = data.main.temp_max + "55&#186;C";
            Temperature_feel.Text = data.main.feels_like + "55&#186;C";
            SetLoadingIndivator(false);
            EnableCountryView();
        }

        public void SetLoadingIndivator(bool condition)
        {
            LoadingIndicator.IsRunning = condition;
        }
    }
}
