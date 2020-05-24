using GreyhamWooHoo.Flutter.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System;

namespace GreyhamWooHoo.Flutter.SystemTests
{
    [TestClass]
    public abstract class TestBase
    {
        // public const string AndroidAppPath = @"C:\temp\android-real-debug.apk";
        public const string AndroidAppPath = @"F:\greyhamwoohoo-private\appium-flutter-driver-net-bindings\src\GreyhamWooHoo.Flutter.TestApp\howdi_welt\build\app\outputs\apk\app.apk";

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
            capabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 120000);

            // TODO: 
            var addressOfRemoteServer = new Uri("http://127.0.0.1:4723/wd/hub");
            var commandExecutor = new HttpCommandExecutor(addressOfRemoteServer, TimeSpan.FromSeconds(60));
            var webDriver = new AndroidDriver<IWebElement>(commandExecutor, capabilities);

            // NOTE: ElementTimeoutInSeconds is the default only for WaitFor and WaitForAbsent at the moment
            var fd = new FlutterDriver(webDriver, commandExecutor, elementTimeoutInSeconds: 30);
            return fd;
        }

        public TestContext TestContext { get; set; }

        protected IFlutterDriver FlutterDriver;

        [TestInitialize]
        public void Setup()
        {
            FlutterDriver = StartApplication();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // I have not implemented this method... some RemoteWebDrviers do not implement .Close() (as below). To be safe: control destruction yourself. 
            // FlutterDriver.Close();

            // FlutterDriver?.WrappedDriver?.Close() - this throws a NotImplemented exception
            FlutterDriver?.WrappedDriver?.Quit();
        }
    }
}
