using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreyhamWooHoo.Flutter.SystemTests
{
    [TestClass]
    public class SessionTests : TestBase
    {
        [TestMethod]
        public void CheckHealth_Javascript()
        {
            var result = FlutterDriver.ExecuteScript("flutter:checkHealth");

            result.Should().Be("ok");
        }

        [TestMethod]
        public void CheckHealth_Driver()
        {
            var result = FlutterDriver.CheckHealth();

            result.Should().Be("ok");

        }

        [TestMethod]
        public void ClearTimeline_Javascript()
        {
            var result = FlutterDriver.ExecuteScript("flutter:clearTimeline");

            result.Should().BeNull();
        }

        [TestMethod]
        public void ClearTimeline_Driver()
        {
            FlutterDriver.ClearTimeline();
        }

        [TestMethod]
        public void ForceGC_Javascript()
        {
            var result = FlutterDriver.ExecuteScript("flutter:forceGC");

            result.Should().BeNull();
        }

        [TestMethod]
        public void ForceGC_Driver()
        {
            FlutterDriver.ForceGC();
        }

        [TestMethod]
        public void GetRenderTree_Javascript()
        {
            var result = FlutterDriver.ExecuteScript("flutter:getRenderTree");

            result.ToString().StartsWith("RenderView#").Should().BeTrue(because: "the render tree always starts with that text");
        }

        [TestMethod]
        public void GetRenderTree_Driver()
        {
            var result = FlutterDriver.GetRenderTree();

            result.ToString().StartsWith("RenderView#").Should().BeTrue(because: "the render tree always starts with that text");
        }
    }
}
