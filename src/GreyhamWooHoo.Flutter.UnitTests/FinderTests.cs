using FluentAssertions;
using GreyhamWooHoo.Flutter.Finder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreyhamWooHoo.Flutter.UnitTests
{
    /// <summary>
    /// NOTE: All tests are backed by a node.js snippet which acts as the source of truth: these snippets can be run in the examples/nodejs/src folder in the appium-flutter-driver repository.
    /// </summary>
    [TestClass]
    public class FinderTests
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

        [TestMethod]
        [DataRow(null, "eyJmaW5kZXJUeXBlIjoiQnlUb29sdGlwTWVzc2FnZSIsInRleHQiOm51bGx9")]
        [DataRow("", "eyJmaW5kZXJUeXBlIjoiQnlUb29sdGlwTWVzc2FnZSIsInRleHQiOiIifQ")]
        [DataRow(" ", "eyJmaW5kZXJUeXBlIjoiQnlUb29sdGlwTWVzc2FnZSIsInRleHQiOiIgIn0")]
        [DataRow("theText", "eyJmaW5kZXJUeXBlIjoiQnlUb29sdGlwTWVzc2FnZSIsInRleHQiOiJ0aGVUZXh0In0")]
        public void ByTooltip(string inputText, string nodeOutputAsBase64)
        {
            // NodeJs Snippet:
            // console.log(find.byTooltip(null))
            // console.log(find.byTooltip(""))
            // console.log(find.byTooltip(" "))
            // console.log(find.byTooltip("theText"))

            // Output:
            // eyJmaW5kZXJUeXBlIjoiQnlUb29sdGlwTWVzc2FnZSIsInRleHQiOm51bGx9
            // eyJmaW5kZXJUeXBlIjoiQnlUb29sdGlwTWVzc2FnZSIsInRleHQiOiIifQ
            // eyJmaW5kZXJUeXBlIjoiQnlUb29sdGlwTWVzc2FnZSIsInRleHQiOiIgIn0
            // eyJmaW5kZXJUeXBlIjoiQnlUb29sdGlwTWVzc2FnZSIsInRleHQiOiJ0aGVUZXh0In0
            var asPageBackFinder = FlutterBy.Tooltip(inputText);

            var asBase64 = asPageBackFinder.ToBase64();

            asBase64.Should().Be(nodeOutputAsBase64, because: "the Base64 Serialization should match the NodeJs version");
        }

        [TestMethod]
        [DataRow(null, "eyJmaW5kZXJUeXBlIjoiQnlUeXBlIiwidHlwZSI6bnVsbH0")]
        [DataRow("", "eyJmaW5kZXJUeXBlIjoiQnlUeXBlIiwidHlwZSI6IiJ9")]
        [DataRow(" ", "eyJmaW5kZXJUeXBlIjoiQnlUeXBlIiwidHlwZSI6IiAifQ")]
        [DataRow("theType", "eyJmaW5kZXJUeXBlIjoiQnlUeXBlIiwidHlwZSI6InRoZVR5cGUifQ")]
        public void ByType(string inputText, string nodeOutputAsBase64)
        {
            // NodeJs Snippet:
            // console.log(find.byType(null))
            // console.log(find.byType(""))
            // console.log(find.byType(" "))
            // console.log(find.byType("theType"))

            // Output:
            // eyJmaW5kZXJUeXBlIjoiQnlUeXBlIiwidHlwZSI6bnVsbH0
            // eyJmaW5kZXJUeXBlIjoiQnlUeXBlIiwidHlwZSI6IiJ9
            // eyJmaW5kZXJUeXBlIjoiQnlUeXBlIiwidHlwZSI6IiAifQ
            // eyJmaW5kZXJUeXBlIjoiQnlUeXBlIiwidHlwZSI6InRoZVR5cGUifQ
            var asPageBackFinder = FlutterBy.Type(inputText);

            var asBase64 = asPageBackFinder.ToBase64();

            asBase64.Should().Be(nodeOutputAsBase64, because: "the Base64 Serialization should match the NodeJs version");
        }

        [TestMethod]
        [DataRow(null, "eyJmaW5kZXJUeXBlIjoiQnlTZW1hbnRpY3NMYWJlbCIsImlzUmVnRXhwIjpmYWxzZSwibGFiZWwiOm51bGx9")]
        [DataRow("", "eyJmaW5kZXJUeXBlIjoiQnlTZW1hbnRpY3NMYWJlbCIsImlzUmVnRXhwIjpmYWxzZSwibGFiZWwiOiIifQ")]
        [DataRow(" ", "eyJmaW5kZXJUeXBlIjoiQnlTZW1hbnRpY3NMYWJlbCIsImlzUmVnRXhwIjpmYWxzZSwibGFiZWwiOiIgIn0")]
        [DataRow("theSemanticsLabel", "eyJmaW5kZXJUeXBlIjoiQnlTZW1hbnRpY3NMYWJlbCIsImlzUmVnRXhwIjpmYWxzZSwibGFiZWwiOiJ0aGVTZW1hbnRpY3NMYWJlbCJ9")]
        public void BySemanticsLabel_NotRegularExpression(string inputText, string nodeOutputAsBase64)
        {
            // NodeJs Snippet:
            // console.log(find.bySemanticsLabel(null))
            // console.log(find.bySemanticsLabel(""))
            // console.log(find.bySemanticsLabel(" "))
            // console.log(find.bySemanticsLabel("theSemanticsLabel"))

            // Output:
            // eyJmaW5kZXJUeXBlIjoiQnlTZW1hbnRpY3NMYWJlbCIsImlzUmVnRXhwIjpmYWxzZSwibGFiZWwiOm51bGx9
            // eyJmaW5kZXJUeXBlIjoiQnlTZW1hbnRpY3NMYWJlbCIsImlzUmVnRXhwIjpmYWxzZSwibGFiZWwiOiIifQ
            // eyJmaW5kZXJUeXBlIjoiQnlTZW1hbnRpY3NMYWJlbCIsImlzUmVnRXhwIjpmYWxzZSwibGFiZWwiOiIgIn0
            // eyJmaW5kZXJUeXBlIjoiQnlTZW1hbnRpY3NMYWJlbCIsImlzUmVnRXhwIjpmYWxzZSwibGFiZWwiOiJ0aGVTZW1hbnRpY3NMYWJlbCJ9
            var asResult = FlutterBy.SemanticsLabel(inputText);

            var asBase64 = asResult.ToBase64();

            asBase64.Should().Be(nodeOutputAsBase64, because: "the Base64 Serialization should match the NodeJs version");
        }

        [TestMethod]
        [DataRow(true, "eyJmaW5kZXJUeXBlIjoiRGVzY2VuZGFudCIsIm1hdGNoUm9vdCI6dHJ1ZSwib2ZfZmluZGVyVHlwZSI6IkJ5VG9vbHRpcE1lc3NhZ2UiLCJvZl90ZXh0IjoidGhlVG9vbHRpcCIsIm1hdGNoaW5nX2ZpbmRlclR5cGUiOiJCeVZhbHVlS2V5IiwibWF0Y2hpbmdfa2V5VmFsdWVTdHJpbmciOiJ0aGVDb3VudGVyIiwibWF0Y2hpbmdfa2V5VmFsdWVUeXBlIjoiU3RyaW5nIn0")]
        [DataRow(false, "eyJmaW5kZXJUeXBlIjoiRGVzY2VuZGFudCIsIm1hdGNoUm9vdCI6ZmFsc2UsIm9mX2ZpbmRlclR5cGUiOiJCeVRvb2x0aXBNZXNzYWdlIiwib2ZfdGV4dCI6InRoZVRvb2x0aXAiLCJtYXRjaGluZ19maW5kZXJUeXBlIjoiQnlWYWx1ZUtleSIsIm1hdGNoaW5nX2tleVZhbHVlU3RyaW5nIjoidGhlQ291bnRlciIsIm1hdGNoaW5nX2tleVZhbHVlVHlwZSI6IlN0cmluZyJ9")]
        public void ByDescendant_MatchRoot(bool matchRoot, string nodeOutputAsBase64)
        {
            // NodeJs Snippet:
            // var result = find.descendant({
            //   of: find.byTooltip('theTooltip'),
            //   matching: find.byValueKey('theCounter'),
            //   matchRoot: matchRoot
            // })
            // console.log(result)

            // NOTE: In the NodeJs version, passing in one of ('of', 'matching') as null will throw an exception - so the case is not handled here either. 
            var asResult = FlutterBy.Descendant(
                of: FlutterBy.Tooltip(tooltip: "theTooltip"),
                matching: FlutterBy.ValueKey("theCounter"),
                matchRoot: matchRoot);

            var asBase64 = asResult.ToBase64();

            asBase64.Should().Be(nodeOutputAsBase64, because: "the Base64 Serialization should match the NodeJs version");
        }

        [TestMethod]
        [DataRow(true, "eyJmaW5kZXJUeXBlIjoiQW5jZXN0b3IiLCJtYXRjaFJvb3QiOnRydWUsIm9mX2ZpbmRlclR5cGUiOiJCeVRvb2x0aXBNZXNzYWdlIiwib2ZfdGV4dCI6InRoZVRvb2x0aXAiLCJtYXRjaGluZ19maW5kZXJUeXBlIjoiQnlWYWx1ZUtleSIsIm1hdGNoaW5nX2tleVZhbHVlU3RyaW5nIjoidGhlQ291bnRlciIsIm1hdGNoaW5nX2tleVZhbHVlVHlwZSI6IlN0cmluZyJ9")]
        [DataRow(false, "eyJmaW5kZXJUeXBlIjoiQW5jZXN0b3IiLCJtYXRjaFJvb3QiOmZhbHNlLCJvZl9maW5kZXJUeXBlIjoiQnlUb29sdGlwTWVzc2FnZSIsIm9mX3RleHQiOiJ0aGVUb29sdGlwIiwibWF0Y2hpbmdfZmluZGVyVHlwZSI6IkJ5VmFsdWVLZXkiLCJtYXRjaGluZ19rZXlWYWx1ZVN0cmluZyI6InRoZUNvdW50ZXIiLCJtYXRjaGluZ19rZXlWYWx1ZVR5cGUiOiJTdHJpbmcifQ")]
        public void ByAncestor_MatchRoot(bool matchRoot, string nodeOutputAsBase64)
        {
            // NodeJs Snippet:
            // var result = find.ancestor({
            //   of: find.byTooltip('theTooltip'),
            //   matching: find.byValueKey('theCounter'),
            //   matchRoot: matchRoot
            // })
            // console.log(result)

            // NOTE: In the NodeJs version, passing in one of ('of', 'matching') as null will throw an exception - so the case is not handled here either. 
            var asResult = FlutterBy.Ancestor(
                of: FlutterBy.Tooltip(tooltip: "theTooltip"),
                matching: FlutterBy.ValueKey("theCounter"),
                matchRoot: matchRoot);

            var asBase64 = asResult.ToBase64();

            asBase64.Should().Be(nodeOutputAsBase64, because: "the Base64 Serialization should match the NodeJs version");
        }

        [TestMethod]
        public void ByDescendant_Recursive()
        {
            var nodeOutputAsBase64 = "eyJmaW5kZXJUeXBlIjoiRGVzY2VuZGFudCIsIm1hdGNoUm9vdCI6ZmFsc2UsIm9mX2ZpbmRlclR5cGUiOiJBbmNlc3RvciIsIm9mX21hdGNoUm9vdCI6ZmFsc2UsIm9mX29mX2ZpbmRlclR5cGUiOiJCeVZhbHVlS2V5Iiwib2Zfb2Zfa2V5VmFsdWVTdHJpbmciOiJjb3VudGVyX3NlbWFudGljIiwib2Zfb2Zfa2V5VmFsdWVUeXBlIjoiU3RyaW5nIiwib2ZfbWF0Y2hpbmdfZmluZGVyVHlwZSI6IkJ5VHlwZSIsIm9mX21hdGNoaW5nX3R5cGUiOiJUb29sdGlwIiwibWF0Y2hpbmdfZmluZGVyVHlwZSI6IkJ5VHlwZSIsIm1hdGNoaW5nX3R5cGUiOiJUZXh0In0";

            // NodeJs Snippet:
            // result = find.descendant({
            //   of: find.ancestor({
            //     of: find.byValueKey('counter_semantic'),
            //     matching: find.byType('Tooltip')
            //   }),
            //   matching: find.byType('Text')
            // })
            // console.log(result)

            // NOTE: In the NodeJs version, passing in one of ('of', 'matching') as null will throw an exception - so the case is not handled here either. 
            var asResult = FlutterBy.Descendant(
                of: FlutterBy.Ancestor(
                    of: FlutterBy.ValueKey("counter_semantic"),
                    matching: FlutterBy.Type("Tooltip"),
                    matchRoot: false),
                matching: FlutterBy.Type("Text"),
                matchRoot: false);

            var asBase64 = asResult.ToBase64();

            asBase64.Should().Be(nodeOutputAsBase64, because: "the Base64 Serialization should match the NodeJs version");
        }

        [TestMethod]
        public void ByAncestor_Recursive()
        {
            var nodeOutputAsBase64 = "eyJmaW5kZXJUeXBlIjoiQW5jZXN0b3IiLCJtYXRjaFJvb3QiOmZhbHNlLCJvZl9maW5kZXJUeXBlIjoiRGVzY2VuZGFudCIsIm9mX21hdGNoUm9vdCI6ZmFsc2UsIm9mX29mX2ZpbmRlclR5cGUiOiJCeVZhbHVlS2V5Iiwib2Zfb2Zfa2V5VmFsdWVTdHJpbmciOiJjb3VudGVyX3NlbWFudGljIiwib2Zfb2Zfa2V5VmFsdWVUeXBlIjoiU3RyaW5nIiwib2ZfbWF0Y2hpbmdfZmluZGVyVHlwZSI6IkJ5VHlwZSIsIm9mX21hdGNoaW5nX3R5cGUiOiJUb29sdGlwIiwibWF0Y2hpbmdfZmluZGVyVHlwZSI6IkJ5VHlwZSIsIm1hdGNoaW5nX3R5cGUiOiJUZXh0In0";

            // NodeJs Snippet:
            // result = find.ancestor({
            //   of: find.descendant({
            //     of: find.byValueKey('counter_semantic'),
            //     matching: find.byType('Tooltip')
            //   }),
            //   matching: find.byType('Text')
            // })
            // console.log(result)

            // NOTE: In the NodeJs version, passing in one of ('of', 'matching') as null will throw an exception - so the case is not handled here either. 
            var asResult = FlutterBy.Ancestor(
                of: FlutterBy.Descendant(
                    of: FlutterBy.ValueKey("counter_semantic"),
                    matching: FlutterBy.Type("Tooltip"),
                    matchRoot: false),
                matching: FlutterBy.Type("Text"),
                matchRoot: false);

            var asBase64 = asResult.ToBase64();

            asBase64.Should().Be(nodeOutputAsBase64, because: "the Base64 Serialization should match the NodeJs version");
        }
    }
}
