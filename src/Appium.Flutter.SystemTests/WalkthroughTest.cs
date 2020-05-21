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
    public class WalkthroughTest : TestBase
    {
        [TestMethod]
        public void GetRenderObjectDiagnostics_Javascript()
        {
            var by = FlutterBy.ValueKey("counter");

            var response = FlutterDriver.ExecuteScript("flutter:getRenderObjectDiagnostics", by.ToBase64(), new Dictionary<string, object>()
            {
                { "includeProperties", true },
                { "subtreeDepth", 2 }
            });

            var responseAsDictionary = response as Dictionary<string, object>;

            AssertGetRenderObjectDiagnosticsResponse(responseAsDictionary);
        }

        [TestMethod]
        public void GetRenderObjectDiagnostics_Driver()
        {
            var response = FlutterDriver.GetRenderObjectDiagnostics(FlutterBy.ValueKey("counter"), includeProperties: true, subtreeDepth: 2);

            AssertGetRenderObjectDiagnosticsResponse(response);
        }

        [TestMethod]
        [Ignore()]
        public void EXP()
        {
            var t = FlutterDriver.ExecuteScript("flutter:getSemanticsId", FlutterBy.Text("Increment 1").ToBase64());
            var result = FlutterDriver.GetElementText(FlutterBy.SemanticsLabel("counter"));

        }

        private void AssertGetRenderObjectDiagnosticsResponse(Dictionary<string, object> response)
        {
            using (var scope = new AssertionScope("GetRenderDiagnosticsResponse"))
            {
                response.ContainsKey("description").Should().BeTrue();
                response.ContainsKey("type").Should().BeTrue();
                response.ContainsKey("children").Should().BeTrue();
                response.ContainsKey("allowWrap").Should().BeTrue();
                response.ContainsKey("properties").Should().BeTrue();
                response.ContainsKey("children").Should().BeTrue();

                response["type"].Should().Be("DiagnosticableTreeNode");
            }
        }
    }
}
