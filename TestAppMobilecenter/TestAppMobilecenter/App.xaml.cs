using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using TestAppMobilecenter.Utils;
using System.Reflection;

namespace TestAppMobilecenter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TestAppMobilecenter.MainPage();
        }

        protected override void OnStart()
        {
            var appsecret = ResourceLoader.GetEmbeddedResourceString(typeof(App).GetTypeInfo().Assembly, "secrets.txt");

            MobileCenter.Start(appsecret,
                   typeof(Analytics), typeof(Crashes));
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
