using Appium.Flutter.Finder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Appium.Flutter.SystemTests
{
    [TestClass]
    public class PagebackTests : TestBase
    {
        [TestInitialize]
        public void NavigateToPageback()
        {
            FlutterDriver.Click(FlutterBy.Text("Navigate to Finders and Position Test Page"));

            // TODO:
            // WaitForNotExist
        }

        [TestMethod]
        public void PageBack()
        {
            // Confirm we are on the page...
            FlutterDriver.Click(FlutterBy.PageBack());

            // Then PageBack
            // TODO: Use WaitFor for the control to appear again
            FlutterDriver.Click(FlutterBy.Text("Navigate to Finders and Position Test Page"));
        }
    }
}
