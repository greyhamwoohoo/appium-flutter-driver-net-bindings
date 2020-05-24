using FluentAssertions;
using GreyhamWooHoo.Flutter.Finder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreyhamWooHoo.Flutter.SystemTests
{
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

        private void AssertCounterIs(string value, string because)
        {
            var result = FlutterDriver.GetText(FlutterBy.ValueKey("counter"));
            result.Should().Be(value, because);
        }
    }
}
