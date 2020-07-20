using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace WeatherSimpleApp
{
    public class DailyDatum
    {
        public int Temeperature { get; set; }
        public string Conditions { get; set; }
        public int Rain { get; set; }
        public int Wind { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }
    public class DailyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        ObservableCollection<DailyDatum> collection { get; set; }
        private string testtext;
        public string TestText { get => testtext; set {
                testtext = value;
                OnPropertyChanged();
            }}

        List<DailyDatum> basicList { get; set; }
        public List<DailyDatum> BasicList
        {
            get => basicList; set
            {
                basicList = value;
                OnPropertyChanged();

            }
        }
        public DailyViewModel()
        {
            collection = new ObservableCollection<DailyDatum>();
            basicList = new List<DailyDatum>();
            DailyDatum na = new DailyDatum();
            na.Temeperature = 22;
            na.Conditions = "Cloudy";
            na.Rain = 52;
            na.Wind = 31;
            na.Sunrise = "at morning";
            na.Sunset = "at afternoon";
            basicList.Add(na);
            collection.Add(na);
            TestText = "testtext";
        }
    }
}
