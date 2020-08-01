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
        // See https://github.com/greyhamwoohoo/appium-flutter-driver-net-bindings-test-app for how to produce this apk
        public static string AndroidAppPath
        {
            get
            {
                // Crude expansion: supports specifying a path in CI
                var result = System.Environment.ExpandEnvironmentVariables(@"%TESTAPP_PATH%");
                if(result == "%TESTAPP_PATH%")
                {
                    result = @"C:\dev.git\appium-flutter-driver-net-bindings-test-app\src\howdi_welt\build\app\outputs\apk\debug\app-debug.apk";
                    result = @"C:\Users\Graham\Downloads\app-debug.apk";
                }
                return result;
            }
        } 

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
            capabilities.AddAdditionalCapability("buildToolsVersion", "28.0.3");
            capabilities.AddAdditionalCapability("uiautomator2ServerInstallTimeout", 60000);
            capabilities.AddAdditionalCapability("uiautomator2ServerLaunchTimeout", 60000);
            capabilities.AddAdditionalCapability("adbExecTimeout", 60000);
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "Flutter");
            capabilities.AddAdditionalCapability(MobileCapabilityType.NoReset, false);
            capabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, ReadEnvironmentVariable("TESTAPP_MOBILECAPABILITYTYPE_NEWCOMMANDTIMEOUT", orFallbackTo: 60000));

            // TODO: 
            var addressOfRemoteServer = new Uri("http://127.0.0.1:4723/wd/hub");
            var commandExecutor = new HttpCommandExecutor(addressOfRemoteServer, TimeSpan.FromSeconds(ReadEnvironmentVariable("TESTAPP_HTTPEXECUTOR_TIMEOUT_IN_SECONDS", orFallbackTo: 120)));
            var webDriver = new AndroidDriver<IWebElement>(commandExecutor, capabilities);

            // NOTE: ElementTimeoutInSeconds is the default only for WaitFor and WaitForAbsent at the moment
            var fd = new FlutterDriver(webDriver, commandExecutor, elementTimeoutInSeconds: 30);
            return fd;
        }

        protected static string ReadEnvironmentVariable(string name, string orFallbackTo)
        {
            var realName = $"%{name}%";
            var result = System.Environment.ExpandEnvironmentVariables(realName);
            if (result == realName)
            {
                result = orFallbackTo;
            }
            Console.WriteLine($"Using value {result} for variable {name}");
            return result;
        }

        protected static int ReadEnvironmentVariable(string name, int orFallbackTo)
        {
            return System.Convert.ToInt32(ReadEnvironmentVariable(name, $"{orFallbackTo}"));
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
