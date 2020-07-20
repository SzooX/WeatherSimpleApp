using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherSimpleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralPage : MasterDetailPage
    {
        public static GeneralPage Instance;
        public GeneralPage()
        {
            if (Instance == null) Instance = this;
            InitializeComponent();
        }
    }
}