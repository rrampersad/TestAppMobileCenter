using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestAppMobilecenter.Commands;

namespace TestAppMobilecenter.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand CrashAppCommand { get; private set; }
        public ICommand IncreaseCountCommand { get; private set; }

        private int _counter;
        public int Counter
        {
            get
            {
                return _counter;
            }
            set
            {

                SetProperty(ref _counter, value);
            }
        }

        public MainPageViewModel()
        {

            CrashAppCommand = new Command(() =>
                                            {
                                                Analytics.TrackEvent("Crash Clicked");
                                                Crashes.GenerateTestCrash();
                                            });
            IncreaseCountCommand = new Command(IncreaseCount);
        }

        private void IncreaseCount()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("Count Clicked", Counter + "");
            Analytics.TrackEvent("Counter", dict);
            Counter++;
        }
    }
}
