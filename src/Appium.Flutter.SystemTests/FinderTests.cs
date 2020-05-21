using Appium.Flutter.Contracts;
using Appium.Flutter.Finder;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Appium.Flutter.SystemTests
{
    /// <summary>
    /// TODO:Create a simple to test each of the commands separately
    /// </summary>
    [TestClass]
    public class FinderTests : TestBase
    {
        [TestInitialize]
        public void ResetCounter()
        {
            // ByType: Reset the counter to 0
            FlutterDriver.Click(FlutterBy.Type("OutlineButton"));
            
            var result = FlutterDriver.GetElementText(FlutterBy.ValueKey("counter"));
            result.Should().Be("0", because: "that is the default value of the Counter. ");
        }

        [TestMethod]
        public void ByText()
        {
            // Text
            FlutterDriver.Click(FlutterBy.Text("Increment 1"));

            AssertCounterIs("1", because: "we pressed the Add+1 button");
        }

        [TestMethod]
        public void ByValueKey()
        {
            // Text
            FlutterDriver.Click(FlutterBy.ValueKey("Up By Two"));

            AssertCounterIs("2", because: "we pressed the Add+2 button");
        }

        [TestMethod]
        public void ByTooltip()
        {
            // Text
            FlutterDriver.Click(FlutterBy.Tooltip("Raise Me By 3"));

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
            FlutterDriver.Click(FlutterBy.SemanticsLabel("Up-By-Four"));

            AssertCounterIs("4", because: "we pressed the Semantics Label button");
        }

        [TestMethod]
        public void GetSemanticsId_ByScript()
        {
            var semanticsId = FlutterDriver.ExecuteScript("flutter:getSemanticsId", FlutterBy.Tooltip("Raise Me By 3").ToBase64());

            semanticsId.Should().BeOfType(typeof(int));

            ((int)semanticsId).Should().NotBe(0);
        }

        [TestMethod]
        public void GetSemanticsId_Driver()
        {
            var semanticsId = FlutterDriver.GetSemanticsId(FlutterBy.Type("FlatButton"));

            ((int)semanticsId).Should().NotBe(0);
        }

        private void AssertCounterIs(string value, string because)
        {
            var result = FlutterDriver.GetElementText(FlutterBy.ValueKey("counter"));
            result.Should().Be(value, because);
        }
    }
}
