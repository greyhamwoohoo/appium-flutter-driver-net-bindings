using GreyhamWooHoo.Flutter.Finder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreyhamWooHoo.Flutter.SystemTests
{
    [TestClass]
    public class PagebackTests : TestBase
    {
        [TestInitialize]
        public void NavigateToPageback()
        {
            FlutterDriver.Click(FlutterBy.Text("Navigate to Finders and Position Test Page"));

            FlutterDriver.WaitForAbsent(FlutterBy.Text("Navigate to Finders and Position Test Page"));
        }

        [TestMethod]
        public void PageBack()
        {
            FlutterDriver.Click(FlutterBy.PageBack());

            FlutterDriver.WaitFor(FlutterBy.Text("Navigate to Finders and Position Test Page"));
        }
    }
}
