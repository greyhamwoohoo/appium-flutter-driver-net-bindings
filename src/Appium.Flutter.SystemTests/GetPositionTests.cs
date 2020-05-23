using Appium.Flutter.Finder;
using Appium.Flutter.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Appium.Flutter.SystemTests
{
    [TestClass]
    public class GetPositionTests : TestBase
    {
        protected static FlutterBy Control = FlutterBy.Type("FlatButton");

        [TestInitialize]
        public void NavigateToFindersPage()
        {
            FlutterDriver.Click(FlutterBy.Text("Navigate to Finders and Position Test Page"));
        }

        [TestMethod]
        public void GetBottomLeft_ByScript()
        {
            var response = FlutterDriver.ExecuteScript("flutter:getBottomLeft", Control.ToBase64());

            AssertPositionResultContract(response);
        }

        [TestMethod]
        public void GetBottomRight_ByScript()
        {
            var response = FlutterDriver.ExecuteScript("flutter:getBottomRight", Control.ToBase64());

            AssertPositionResultContract(response);
        }

        [TestMethod]
        public void GetTopLeft_ByScript()
        {
            var result = FlutterDriver.ExecuteScript("flutter:getTopLeft", Control.ToBase64());

            AssertPositionResultContract(result);
        }

        [TestMethod]
        public void GetTopRight_ByScript()
        {
            var response = FlutterDriver.ExecuteScript("flutter:getTopRight", Control.ToBase64());

            AssertPositionResultContract(response);
        }

        [TestMethod]
        public void GetCenter_ByScript()
        {
            var response = FlutterDriver.ExecuteScript("flutter:getCenter", Control.ToBase64());

            AssertPositionResultContract(response);
        }

        [TestMethod]
        public void GetPosition_ValuesAreCongruent_ByScript()
        {
            // If other tests fail in this class: fix those first. 
            var topLeft = GetPosition_ByScript("flutter:getTopLeft");
            var topRight = GetPosition_ByScript("flutter:getTopRight");
            var bottomLeft = GetPosition_ByScript("flutter:getBottomLeft");
            var bottomRight = GetPosition_ByScript("flutter:getBottomRight");
            var center = GetPosition_ByScript("flutter:getCenter");

            // The bounding box is a square
            topLeft.Dx.Should().Be(bottomLeft.Dx, because: "the left boundary is a straight vertical line");
            topRight.Dx.Should().Be(bottomRight.Dx, because: "the right boundary is a straiight vertical line");

            topLeft.Dy.Should().Be(topRight.Dy, because: "the top boundary is a straight horizontal line");
            bottomLeft.Dy.Should().Be(bottomRight.Dy, because: "the bottom boundary is a straight horizontal line");

            topLeft.Dx.Should().BeLessThan(center.Dx, "thats just the way a square rocks and rolls");
            topLeft.Dy.Should().BeLessThan(center.Dy, "thats just the way a square rocks and rolls");
            bottomLeft.Dx.Should().BeLessThan(center.Dx, "thats just the way a square rocks and rolls");
            bottomLeft.Dy.Should().BeGreaterThan(center.Dy, "thats just the way a square rocks and rolls (using (X,Y) == (0,0) coords");

            topRight.Dx.Should().BeGreaterThan(center.Dx, "thats just the way a square rocks and rolls");
            topRight.Dy.Should().BeLessThan(center.Dy, "thats just the way a square rocks and rolls");
            bottomRight.Dx.Should().BeGreaterThan(center.Dx, "thats just the way a square rocks and rolls");
            bottomRight.Dy.Should().BeGreaterThan(center.Dy, "thats just the way a square rocks and rolls");
        }

        [TestMethod]
        public void GetBottomLeft_Driver()
        {
            var response = FlutterDriver.GetBottomLeft(Control);

            response.Dx.Should().BeGreaterThan(0);
            response.Dy.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void GetBottomRight_Driver()
        {
            var response = FlutterDriver.GetBottomRight(Control);

            response.Dx.Should().BeGreaterThan(0);
            response.Dy.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void GetTopleft_Driver()
        {
            var response = FlutterDriver.GetTopLeft(Control);

            response.Dx.Should().BeGreaterThan(0);
            response.Dy.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void GetTopRight_Driver()
        {
            var response = FlutterDriver.GetTopRight(Control);

            response.Dx.Should().BeGreaterThan(0);
            response.Dy.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void GetCenter_Driver()
        {
            var response = FlutterDriver.GetCenter(Control);

            response.Dx.Should().BeGreaterThan(0);
            response.Dy.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void GetPosition_ValuesAreCongruent_ByDriver()
        {
            // If other tests fail in this class: fix those first. 
            var topLeft = FlutterDriver.GetTopLeft(Control);
            var topRight = FlutterDriver.GetTopRight(Control);
            var bottomLeft = FlutterDriver.GetBottomLeft(Control);
            var bottomRight = FlutterDriver.GetBottomRight(Control);
            var center = FlutterDriver.GetCenter(Control);

            // The bounding box is a square
            topLeft.Dx.Should().Be(bottomLeft.Dx, because: "the left boundary is a straight vertical line");
            topRight.Dx.Should().Be(bottomRight.Dx, because: "the right boundary is a straiight vertical line");

            topLeft.Dy.Should().Be(topRight.Dy, because: "the top boundary is a straight horizontal line");
            bottomLeft.Dy.Should().Be(bottomRight.Dy, because: "the bottom boundary is a straight horizontal line");

            topLeft.Dx.Should().BeLessThan(center.Dx, "thats just the way a square rocks and rolls");
            topLeft.Dy.Should().BeLessThan(center.Dy, "thats just the way a square rocks and rolls");
            bottomLeft.Dx.Should().BeLessThan(center.Dx, "thats just the way a square rocks and rolls");
            bottomLeft.Dy.Should().BeGreaterThan(center.Dy, "thats just the way a square rocks and rolls (using (X,Y) == (0,0) coords");

            topRight.Dx.Should().BeGreaterThan(center.Dx, "thats just the way a square rocks and rolls");
            topRight.Dy.Should().BeLessThan(center.Dy, "thats just the way a square rocks and rolls");
            bottomRight.Dx.Should().BeGreaterThan(center.Dx, "thats just the way a square rocks and rolls");
            bottomRight.Dy.Should().BeGreaterThan(center.Dy, "thats just the way a square rocks and rolls");
        }

        private Position GetPosition_ByScript(string position)
        {
            var response = FlutterDriver.ExecuteScript(position, Control.ToBase64()) as Dictionary<string, object>;
            return new Position((double)response["dx"], (double)response["dy"]);
        }

        private void AssertPositionResultContract(object response)
        {
            response.Should().NotBeNull(because: "the response should be a dictionary containing keys dx and dy");

            var dictionary = response as Dictionary<string, object>;
            dictionary.Should().NotBeNull(because: "the response should be a dictionary containing keys dx and dy");

            dictionary.ContainsKey("dx").Should().BeTrue(because: "the position APIs always return a dx property");
            dictionary.ContainsKey("dy").Should().BeTrue(because: "the position APIs always return a dy property");
        }
    }
}
