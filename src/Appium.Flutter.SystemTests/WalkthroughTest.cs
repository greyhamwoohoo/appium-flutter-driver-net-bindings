using Appium.Flutter.Contracts;
using Appium.Flutter.Finder;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Appium.Flutter.SystemTests
{
    /// <summary>
    /// TODO:Create a simple to test each of the commands separately
    /// </summary>
    [TestClass]
    public class WalkthroughTest : TestBase
    {
        protected static IFlutterDriver FlutterDriver;

        [ClassInitialize]
        public static void Setup(TestContext _)
        {
            FlutterDriver = StartApplication();
        }

        [TestMethod]
        public void Walkthrough()
        {
            var result = FlutterDriver.GetElementText(FlutterBy.ValueKey("counter"));

            result.Should().Be("0", because: "that is the default value of the Couner. ");
        }
    }
}
