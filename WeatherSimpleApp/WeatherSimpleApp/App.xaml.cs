using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherSimpleApp;
using WeatherSimpleApp.Models;

namespace WeatherSimpleApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new GeneralPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            // Initialize last countries system
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            
            WeatherSimpleApp.MainPage.Instance?.UpdateWeather();
        }
    }
}
