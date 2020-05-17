using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Appium.Flutter.UnitTests
{
    /// <summary>
    /// NOTE: All tests are backed by a node.js snippet which acts as the source of truth: these snippets can be run in the examples/nodejs/src folder in the appium-flutter-driver repository.
    /// </summary>
    [TestClass]
    public class FlutterByTests
    {
        [TestMethod]
        public void ByValueKeyIsString()
        {
            // NodeJs Snippet: 
            // const aStringValueKeyFinder = find.byValueKey('counter');
            // console.log("The Counter Text String: " + aStringValueKeyFinder);

            // Output:
            // The Counter Text String: eyJmaW5kZXJUeXBlIjoiQnlWYWx1ZUtleSIsImtleVZhbHVlU3RyaW5nIjoiY291bnRlciIsImtleVZhbHVlVHlwZSI6IlN0cmluZyJ9
            var asFlutterFinder = FlutterBy.ValueKey("counter");

            var asBase64 = asFlutterFinder.ToBase64();

            asBase64.Should().Be("eyJmaW5kZXJUeXBlIjoiQnlWYWx1ZUtleSIsImtleVZhbHVlU3RyaW5nIjoiY291bnRlciIsImtleVZhbHVlVHlwZSI6IlN0cmluZyJ9", because: "the Base64 Serialization should match the NodeJs version");
        }

        [TestMethod]
        public void ByValueKeyIsInt()
        {
            // NodeJs Snippet: 
            // const anIntValueKeyFinder = find.byValueKey(100);
            // console.log("The Counter Int String: " + anIntValueKeyFinder);

            // Output:
            // The Counter Int String: eyJmaW5kZXJUeXBlIjoiQnlWYWx1ZUtleSIsImtleVZhbHVlU3RyaW5nIjoxMDAsImtleVZhbHVlVHlwZSI6ImludCJ9
            var asFlutterFinder = FlutterBy.ValueKey(100);

            var asBase64 = asFlutterFinder.ToBase64();

            asBase64.Should().Be("eyJmaW5kZXJUeXBlIjoiQnlWYWx1ZUtleSIsImtleVZhbHVlU3RyaW5nIjoxMDAsImtleVZhbHVlVHlwZSI6ImludCJ9", because: "the Base64 Serialization should match the NodeJs version");
        }
    }
}
