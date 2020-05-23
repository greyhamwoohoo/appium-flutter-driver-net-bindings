using Appium.Flutter.Finder;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Appium.Flutter.SystemTests
{
    [TestClass]
    public class ScreenshotTests : TestBase
    {
        protected string OutputPath;

        [TestInitialize]
        public void SetupScreenshotTests()
        {
            // NOTE: If we take the screenshot immediately on app startup, we occasionally get this error:
            // Original error: {"code":-32000,"message":"Could not capture image screenshot."}
            //
            // So its better to wait for some state to converge first
            FlutterDriver.WaitFor(FlutterBy.Text("Navigate to Finders and Position Test Page"));

            OutputPath = System.IO.Path.Combine(TestContext.TestRunResultsDirectory, $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.png");
        }

        [TestMethod]
        public void Screenshot_Raw()
        {
            var result = FlutterDriver.Screenshot();
            result.Length.Should().BeGreaterThan(0, because: "we are expecting a screenshot to be returned. ");

            System.IO.File.WriteAllBytes(OutputPath, result);

            System.Drawing.Image.FromFile(OutputPath);
        }

        [TestMethod]
        public void Screenshot_Save()
        {
            FlutterDriver.Screenshot(OutputPath);

            System.Drawing.Image.FromFile(OutputPath);
        }
    }
}
