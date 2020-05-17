using Appium.Flutter.Finder;
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

        [TestMethod]
        public void PageBack()
        {
            // NodeJs Snippet:
            // console.log(find.pageBack())

            // Output:
            // eyJmaW5kZXJUeXBlIjoiUGFnZUJhY2sifQ
            var asPageBackFinder = FlutterBy.PageBack();

            var asBase64 = asPageBackFinder.ToBase64();

            asBase64.Should().Be("eyJmaW5kZXJUeXBlIjoiUGFnZUJhY2sifQ", because: "the Base64 Serialization should match the NodeJs version");
        }

        [TestMethod]
        [DataRow(null, "eyJmaW5kZXJUeXBlIjoiQnlUZXh0IiwidGV4dCI6bnVsbH0")]
        [DataRow("", "eyJmaW5kZXJUeXBlIjoiQnlUZXh0IiwidGV4dCI6IiJ9")]
        [DataRow(" ", "eyJmaW5kZXJUeXBlIjoiQnlUZXh0IiwidGV4dCI6IiAifQ")]
        [DataRow("theText", "eyJmaW5kZXJUeXBlIjoiQnlUZXh0IiwidGV4dCI6InRoZVRleHQifQ")]
        public void ByText(string inputText, string nodeOutputAsBase64)
        {
            // NodeJs Snippet:
            // console.log(find.byText(null))
            // console.log(find.byText(""))
            // console.log(find.byText(" "))
            // console.log(find.byText("theText"))

            // Output:
            // eyJmaW5kZXJUeXBlIjoiQnlUZXh0IiwidGV4dCI6bnVsbH0
            // eyJmaW5kZXJUeXBlIjoiQnlUZXh0IiwidGV4dCI6IiJ9
            // eyJmaW5kZXJUeXBlIjoiQnlUZXh0IiwidGV4dCI6IiAifQ
            // eyJmaW5kZXJUeXBlIjoiQnlUZXh0IiwidGV4dCI6InRoZVRleHQifQ
            var asPageBackFinder = FlutterBy.Text(inputText);

            var asBase64 = asPageBackFinder.ToBase64();

            asBase64.Should().Be(nodeOutputAsBase64, because: "the Base64 Serialization should match the NodeJs version");
        }
    }
}
