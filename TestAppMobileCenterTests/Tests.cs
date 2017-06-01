using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Microsoft.Azure.Mobile.Crashes;

namespace TestAppMobileCenterTests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void AppCrashesWhenCrashButtonIsPressed()
        {
            var button = app.Query(c => c.Button("CrashButton")).FirstOrDefault();

            Assert.IsNotNull(button);

            Assert.Equals(button.Text, "Crash the App");

            Assert.Throws<TestCrashException>(() => app.Tap(c => c.Button("CrashButton")));
        }

        [Test]
        public void AppButtonIsNotNull()
        {
            var button = app.Query(c => c.Button("IncreasCountButton")).FirstOrDefault();

            Assert.IsNotNull(button);

            Assert.Equals(button.Text, "Increase Counter");
        }
    }
}

