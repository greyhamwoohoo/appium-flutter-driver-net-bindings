using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Internal;

namespace GreyhamWooHoo.Flutter.SystemTests
{
    [TestClass]
    public class ConstructionTests : TestBase
    {
        [TestMethod]
        public void FlutterDriver_WrapsDriver()
        {
            var result = FlutterDriver as IWrapsDriver;
            
            result.Should().NotBeNull(because: "the FlutterDriver supports the wrapped underlying driver. ");

            result.WrappedDriver.Should().BeAssignableTo<AndroidDriver<IWebElement>>(because: "the underlying driver is for Android. ");
        }
    }
}
