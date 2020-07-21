using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherSimpleApp.Models;
using WeatherSimpleApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherSimpleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralPageMaster : ContentPage
    {
        public ListView ListView;
        LastCountries lastCountries = new LastCountries();
        public GeneralPageMaster()
        {
            InitializeComponent();

            BindingContext = this;
        }
        class GeneralPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<GeneralPageMasterMenuItem> MenuItems { get; set; }

            public GeneralPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<GeneralPageMasterMenuItem>(new[]
                {
                    new GeneralPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new GeneralPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new GeneralPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new GeneralPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new GeneralPageMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void CountrySearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            GlobalVariables.currentCountry = CountrySearchBar.Text;
            GeneralPage.Instance.IsPresented = false;
            MainPage.Instance.SetLoadingIndicator(true);
            MainPage.Instance.UpdateWeather();
        }

        private void CountryButton1_Pressed(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GlobalVariables.currentCountry = btn.Text;
            GeneralPage.Instance.IsPresented = false;
            MainPage.Instance.SetLoadingIndicator(true);
            MainPage.Instance.UpdateWeather();
        }

        private void CountryButton2_Pressed(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GlobalVariables.currentCountry = btn.Text;
            GeneralPage.Instance.IsPresented = false;
            MainPage.Instance.SetLoadingIndicator(true);
            MainPage.Instance.UpdateWeather();
        }

        private void CountryButton3_Pressed(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GlobalVariables.currentCountry = btn.Text;
            GeneralPage.Instance.IsPresented = false;
            MainPage.Instance.SetLoadingIndicator(true);
            MainPage.Instance.UpdateWeather();
        }
    }
}