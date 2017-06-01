using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TestAppMobileCenterTests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
#if DEBUG
                return ConfigureApp
                    .Android
                    .ApkFile(@"..\..\..\TestAppMobilecenter\TestAppMobilecenter.Android\bin\Debug\TestAppMobilecenter.Android.apk")
                    .PreferIdeSettings()
                    .EnableLocalScreenshots()
                    .StartApp();
#else
                return ConfigureApp
                    .Android
                    .PreferIdeSettings()
                    .ApkFile(@"..\..\..\TestAppMobilecenter\TestAppMobilecenter.Android\bin\Release\TestAppMobilecenter.Android.apk")
                    .EnableLocalScreenshots()
                    .StartApp();
#endif
            }

            return ConfigureApp                
                .iOS
                .PreferIdeSettings()
                .EnableLocalScreenshots()
                .StartApp();
        }
    }
}

