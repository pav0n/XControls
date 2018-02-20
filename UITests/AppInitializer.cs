using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XControlsTest.UITests
{
    public class AppInitializer
    {
        const string simId = "949690C6-66EE-4F1A-9E4F-1D0CAD1E862A"; //iPhone 5s (8.1 Simulator)
        const string bid = "com.xcontrol.XControlsTest";
        const string appFile = "/Users/pav0n/XControls/iOS/bin/iPhoneSimulator/Debug/XControlsTest.iOS.app";
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.StartApp();
            }
            //ResetSimulator(simId);
            return ConfigureApp.iOS.EnableLocalScreenshots()
                               .StartApp();
        }

        static void ResetSimulator(string deviceId)
        {
            var shutdownProcess = Process.Start("xcrun", string.Format("simctl shutdown {0}", deviceId));
            shutdownProcess.WaitForExit();
            var eraseProcess = Process.Start("xcrun", string.Format("simctl erase {0}", deviceId));
            eraseProcess.WaitForExit();
        }
    }
}
