using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaAppDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "Shapes_Experimental" });
            MainPage = new NavigationPage(new Views.MainView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
