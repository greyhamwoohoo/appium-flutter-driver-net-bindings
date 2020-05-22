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
            // SLEEP: If we take the screenshot immediately on app startup, we occasionally get this error:
            // Original error: {"code":-32000,"message":"Could not capture image screenshot."}
            //
            // In practice, in a test, that won't happen because we will already be in the app itself. 
            System.Threading.Thread.Sleep(3000);

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
