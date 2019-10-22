using AppXamarin.Configuration;
using AppXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppXamarin
{
    public partial class App : Application
    {
        private static IoCConfiguration _Locator;

        public static IoCConfiguration Locator
        {
            get
            {
                return _Locator = _Locator ?? new IoCConfiguration();
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PrincipalMaster());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
