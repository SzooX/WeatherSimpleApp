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
        WeatherClient wc = new WeatherClient();
        public MainPage()
        {
            //testmethod();
            //testmethod2();
            //testmethod3();
            InitializeComponent();
            
           
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
    }
}
