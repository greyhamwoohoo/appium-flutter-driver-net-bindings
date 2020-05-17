using Appium.Flutter.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Internal;

namespace Appium.Flutter.SystemTests
{
    [TestClass]
    public class ConstructionTests : TestBase
    {
        protected static IFlutterDriver FlutterDriver;

        [ClassInitialize]
        public static void Setup(TestContext _)
        {
            FlutterDriver = StartApplication();
        }

        [TestMethod]
        public void FlutterDriver_WrapsDriver()
        {
            var result = FlutterDriver as IWrapsDriver;
            
            result.Should().NotBeNull(because: "the FlutterDriver supports the wrapped underlying driver. ");

            result.WrappedDriver.Should().BeAssignableTo<AndroidDriver<IWebElement>>(because: "the underlying driver is for Android. ");
        }
    }
}
