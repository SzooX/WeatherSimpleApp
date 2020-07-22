using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using WeatherSimpleApp.Models;

namespace WeatherSimpleApp
{
    public class DailyDatum
    {
        public string Date { get; set; }
        public string Temeperature { get; set; }
        public string Conditions { get; set; }
        public string Rain { get; set; }
        public string Wind { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }
    public class DailyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static DailyViewModel Instance;
        
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region properties / variables
        DailyData DailyD;
        WeatherClient WC = new WeatherClient();
        ObservableCollection<DailyDatum> basicList { get; set; }
        public ObservableCollection<DailyDatum> BasicList
        {
            get => basicList;
            set
            {
                basicList = value;
                OnPropertyChanged();
                
            }
        }
        bool noPlaceSetted{ get; set; }
        public bool NoPlaceSetted { get => noPlaceSetted; set{
                noPlaceSetted = value;
                OnPropertyChanged();
            }}
        bool loadingIndicator{ get; set; }
        public bool LoadingIndicator { get => loadingIndicator; set{
                loadingIndicator = value;
                OnPropertyChanged();
            }}
        
        #endregion

        public DailyViewModel()
        {
            if (Instance == null) Instance = this;
            BasicList = new ObservableCollection<DailyDatum>();
            NoPlaceSetted = true;
            LoadingIndicator = false;
        }
        public async void UpdateWeather()
        {
            BasicList = new ObservableCollection<DailyDatum>();
            
            // If no country set, return
            if (string.IsNullOrEmpty(GlobalVariables.currentCountry))
            {
                
                return;
            }
            NoPlaceSetted = false;
            LoadingIndicator = true;
            DailyD = await WC.GetWeatherDaily(GlobalVariables.currentCountry);

            for (int i = 1; i < DailyD.daily.Length; i++)
            {
                DailyDatum na = new DailyDatum();
                na.Temeperature = $"{Math.Round(DailyD.daily[i].temp.day)}C";
                na.Conditions = DailyD.daily[i].weather[0].main;
                na.Rain = $"{DailyD.daily[i].rain}mm";
                na.Wind = $"{DailyD.daily[i].wind_speed}m/s";
                na.Sunrise = $"{GetHourString(DailyD.daily[i].sunrise, DailyD.timezone)} AM";
                na.Sunset = $"{GetHourString(DailyD.daily[i].sunset, DailyD.timezone)} PM";
                na.Date = $"{TimeConverter.UnixTimeStampToDateTime(DailyD.daily[i].sunset, DailyD.timezone).DayOfWeek}";
                BasicList.Add(na);
            }
           /* 
            foreach (Daily x in DailyD.daily)
            {
                DailyDatum na = new DailyDatum();
                na.Temeperature = $"{Math.Round(x.temp.day)}C";
                na.Conditions = x.weather[0].main;
                na.Rain = $"{x.rain}mm";
                na.Wind = $"{x.wind_speed}m/s";
                na.Sunrise = $"{GetHourString(x.sunrise, DailyD.timezone)} AM";
                na.Sunset = $"{GetHourString(x.sunset, DailyD.timezone)} PM";
                na.Date = $"{TimeConverter.UnixTimeStampToDateTime(x.sunset, DailyD.timezone).DayOfWeek}";
                BasicList.Add(na);
            }*/
            LoadingIndicator = false;
        }
        string GetHourString(double unittime, string zname)
        {
            DateTime dt = TimeConverter.UnixTimeStampToDateTime(unittime, zname);
            string first = dt.Hour.ToString();
            string second = dt.Minute < 10 ? $"0{dt.Minute}" : dt.Minute.ToString();
            string final = $"{first}:{second}";
            return final;

        }
    }
}
