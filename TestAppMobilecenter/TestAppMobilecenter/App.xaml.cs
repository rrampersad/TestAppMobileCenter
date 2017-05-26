using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TestAppMobilecenter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TestAppMobilecenter.MainPage();
        }

        const string appSecretAndroid = "06fd0889-665e-4e1b-b33a-093b3e67b207";

        protected override void OnStart()
        {
            MobileCenter.Start("android=06fd0889-665e-4e1b-b33a-093b3e67b207;" +
                   "uwp={Your UWP App secret here};" +
                   "ios={Your iOS App secret here}",
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
