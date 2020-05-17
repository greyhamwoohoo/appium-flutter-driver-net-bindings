using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System;

namespace Appium.Flutter.SystemTests
{
    [TestClass]
    public abstract class TestBase
    {
        public const string AndroidAppPath = @"C:\temp\android-real-debug.apk";

        protected static IFlutterDriver StartApplication()
        {
            if (!System.IO.File.Exists(AndroidAppPath)) throw new System.IO.FileNotFoundException($"To run the system tests, you need the sample app at '{AndroidAppPath}'. See the README.md file for more information. ");

            var capabilities = new AppiumOptions();
            
            // Emulator and App Path
            capabilities.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, AndroidAppPath);

            // Other stuff
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 2");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10");
            capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.NativeWebScreenshot, false);
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "Flutter");
            capabilities.AddAdditionalCapability(MobileCapabilityType.NoReset, false);
            capabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 60000);

            // TODO: 
            Uri addressOfRemoteServer = new Uri("http://127.0.0.1:4723/wd/hub");
            var commandExecutor = new HttpCommandExecutor(addressOfRemoteServer, TimeSpan.FromSeconds(60));
            var androidDriver = new AndroidDriver<IWebElement>(commandExecutor, capabilities);

            var fd = new FlutterDriver(androidDriver, commandExecutor);
            return fd;
        }

        public TestContext TestContext { get; set; }
    }
}
