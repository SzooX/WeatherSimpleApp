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
        ActualData data;
        public MainPage()
        {
            // TODO: Load last selected country


            if (Instance == null) Instance = this;

            InitializeComponent();

            if (string.IsNullOrEmpty(GlobalVariables.currentCountry))
            {
                HideData();
            }
            else
            {
                ShowData();
            }
           
        }

        public async void UpdateWeather()
        {
            // If no country set, return
            if (string.IsNullOrEmpty(GlobalVariables.currentCountry)) {
                HideData();
                SetLoadingIndicator(false);
                return;
            }

            data = await wc.GetWeatherActual(GlobalVariables.currentCountry);
            
            // If we have data, show data
            if(data == null)
            {
                Error.IsVisible = true;

                Temperature_now.Text = "N/A";
                Temperature_min.Text = "N/A";
                Temperature_max.Text = "N/A";
                Temperature_feel.Text = "N/A";

                Conditions_humidity.Text = "N/A";
                Conditions_pressure.Text = "N/A";
                Conditions_cloudy.Text = "N/A";

                Wind_speed.Text = "N/A";
            }
            else
            {
                Error.IsVisible = false;

                Temperature_now.Text = Math.Round(data.main.temp) + "°C";
                Temperature_min.Text = Math.Round(data.main.temp_min) + "°C";
                Temperature_max.Text = Math.Round(data.main.temp_max) + "°C";
                Temperature_feel.Text = Math.Round(data.main.feels_like) + "°C";

                Conditions_humidity.Text = data.main.humidity + "%";
                Conditions_pressure.Text = data.main.pressure + "hPa";
                Conditions_cloudy.Text = data.clouds.all + "%";

                Wind_speed.Text = (int)(3.6 * data.wind.speed) + "Km/h";
            }

            // Disable loading indicator and show data
            SetLoadingIndicator(false);
            ShowData();

            // Check is Wind expander opened, if yes rotate direction image
            if (WindExpander.IsExpanded) RotateDirectionImage();
        }


        private void WindExpander_Tapped(object sender, EventArgs e)
        {
            if (WindExpander.IsExpanded)
            {
                Scroll.ScrollToAsync(0, Scroll.ContentSize.Height, true);
                RotateDirectionImage();
            }
        }

        async void RotateDirectionImage()
        {
            if(data != null)
            {
                var rotaton = data.wind.deg;

                // Calculate direction of rotation
                if (rotaton > 180) rotaton = (360 - rotaton) * -1;


                // Rotate direction image (custom animation)
                await Wind_direction.RotateTo(rotaton + (rotaton > 0 ? 15 : -15), 450);
                await Wind_direction.RotateTo(rotaton + (rotaton > 0 ? -10 : 10), 900);
                await Wind_direction.RotateTo(rotaton, 1000);
            }
            else
            {
                while(data == null)
                {
                    Random _random = new Random();
                    await Wind_direction.RotateTo(_random.Next(360), 1000);
                }
            }
        }

        public void HideData()
        {
            NoCountryLabel.IsVisible = true;
            TemperatureBox.IsVisible = false;
            ConditionsBox.IsVisible = false;
            WindBox.IsVisible = false;
        }

        public void ShowData()
        {
            NoCountryLabel.IsVisible = false;
            TemperatureBox.IsVisible = true;
            ConditionsBox.IsVisible = true;
            WindBox.IsVisible = true;
        }

        public void SetLoadingIndicator(bool condition)
        {
            LoadingIndicator.IsRunning = condition;
            LoadingIndicator.IsVisible = condition;
        }
    }
}
