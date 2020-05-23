using Appium.Flutter.Finder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Appium.Flutter.SystemTests
{
    [TestClass]
    public class TextTests : TestBase
    {
        FlutterBy TextFieldControl = FlutterBy.Type("TextField");

        [TestInitialize]
        public void NavigateToTextTestPage()
        {
            FlutterDriver.Click(FlutterBy.Text("Navigate to Text Fields Test Page"));

            FlutterDriver.WaitFor(TextFieldControl);
        }

        [TestMethod]
        public void EnterText()
        {
            FlutterDriver.SendKeys(TextFieldControl, "something");

            // NOTE: Not sure of the API to retrieve the text value of the given control... 
        }

        [TestMethod]
        public void ClearText()
        {
            FlutterDriver.SendKeys(TextFieldControl, "something");
            FlutterDriver.Clear(TextFieldControl);
        }
    }
}
