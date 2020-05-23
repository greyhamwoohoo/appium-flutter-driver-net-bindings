using Appium.Flutter.Finder;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Appium.Flutter.SystemTests
{
    /// <summary>
    /// TODO:Create a simple to test each of the commands separately
    /// </summary>
    [TestClass]
    public class FinderTests : TestBase
    {
        [TestInitialize]
        public void NavigateToFindersPage()
        {
            FlutterDriver.Click(FlutterBy.Text("Navigate to Finders and Position Test Page"));
        }

        [TestMethod]
        public void ByText()
        {
            // Text
            FlutterDriver.Click(FlutterBy.Text("FUT: FlutterBy.Text (Increment 1)"));

            AssertCounterIs("1", because: "we pressed the Add+1 button");
        }

        [TestMethod]
        public void ByValueKey()
        {
            // Text
            FlutterDriver.Click(FlutterBy.ValueKey("FUT: FlutterBy.ValueKey (Increment 2)"));

            AssertCounterIs("2", because: "we pressed the Add+2 button");
        }

        [TestMethod]
        public void ByTooltip()
        {
            // Text
            FlutterDriver.Click(FlutterBy.Tooltip("FUT: FlutterBy.Tooltip (Increment 3)"));

            AssertCounterIs("3", because: "we pressed the Add+3 button");
        }

        [TestMethod]
        public void ByType()
        {
            // Text
            FlutterDriver.Click(FlutterBy.Type("FlatButton"));

            AssertCounterIs("-4", because: "we pressed the Add button (Flat Button)");
        }

        [TestMethod]
        public void BySemanticsLabel()
        {
            // Text
            FlutterDriver.Click(FlutterBy.SemanticsLabel("FUT: FlutterBy.SemanticsLabel (Increment 4)"));

            AssertCounterIs("4", because: "we pressed the Semantics Label button");
        }

        [TestMethod]
        public void GetSemanticsId_ByScript()
        {
            var result = FlutterDriver.ExecuteScript("flutter:getSemanticsId", FlutterBy.Tooltip("FUT: FlutterBy.Tooltip (Increment 3)").ToBase64());

            result.Should().BeOfType(typeof(long));

            ((long)result).Should().NotBe(0);
        }

        [TestMethod]
        public void GetSemanticsId_Driver()
        {
            var semanticsId = FlutterDriver.GetSemanticsId(FlutterBy.Type("FlatButton"));

            semanticsId.Should().NotBe(0);
        }

        [TestMethod]
        public void WaitFor_ByScript()
        {
            // TODO: This throws a Timeout exception if the element is not found (should it be NoSuchElement or otherwise?)
            FlutterDriver.ExecuteScript("flutter:waitFor", FlutterBy.Text("FUT: FlutterBy.Text (Increment 1)").ToBase64());
        }

        [TestMethod]
        public void WaitFor_Driver()
        {
            // TODO: This throws a Timeout exception if the element is not found (should it be NoSuchElement or otherwise?)
            FlutterDriver.WaitFor(FlutterBy.Text("FUT: FlutterBy.Text (Increment 1)"));
        }

        private void AssertCounterIs(string value, string because)
        {
            var result = FlutterDriver.GetElementText(FlutterBy.ValueKey("counter"));
            result.Should().Be(value, because);
        }
    }
}
