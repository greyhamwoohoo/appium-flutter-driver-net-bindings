using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Appium.Flutter.SystemTests
{
    [TestClass]
    public class CheckHealthTests : TestBase
    {
        protected static IFlutterDriver FlutterDriver;

        [ClassInitialize]
        public static void Setup(TestContext _)
        {
            FlutterDriver = StartApplication();
        }

        [TestMethod]
        public void CheckHealth_Javascript()
        {
            var result = FlutterDriver.ExecuteScript("flutter:checkHealth");

            AssertCheckHealthIs(result.ToString(), "ok");
        }

        [TestMethod]
        public void CheckHealth_Driver()
        {
            var result = FlutterDriver.CheckHealth();

            AssertCheckHealthIs(result, "ok");
        }

        private void AssertCheckHealthIs(string result, string status)
        {
            result.Should().Be(status);
        }
    }
}
