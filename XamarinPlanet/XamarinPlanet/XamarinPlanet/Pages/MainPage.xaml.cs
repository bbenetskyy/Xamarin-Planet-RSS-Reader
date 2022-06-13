using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace XamarinPlanet
{
    public partial class MainPage : MvxContentPage<MainPageModel>
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            On<iOS>().SetUseSafeArea(false);
            var safeAreaInsets = On<iOS>().SafeAreaInsets();
            HeaderFrame.Padding = new Thickness(24, 24 + safeAreaInsets.Top, 24, 24);
        }
    }
}

