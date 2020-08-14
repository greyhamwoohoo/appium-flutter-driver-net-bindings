using FluentAssertions;
using GreyhamWooHoo.Flutter.Finder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreyhamWooHoo.Flutter.SystemTests
{
    [TestClass]
    public class RelativeTests : TestBase
    {
        // This locator can match two controls on the page - one in a Row where the button is active; and another Row where it is not. 
        protected FlutterBy TapControl = FlutterBy.Text("FUT:+1 (tap), +10 (long tap)");

        [TestInitialize]
        public void NavigateToRelativePage()
        {
            FlutterDriver.Click(FlutterBy.Text("Navigate to Relative Test Page"));

            FlutterDriver.WaitFor(FlutterBy.Text("Relative Test Page"));

            FlutterDriver.GetText(FlutterBy.ValueKey("tapCounter")).Should().Be("0", because: "the counter is initially 0");
        }

        [TestMethod]
        [Ignore(message: "I cannot get relative locators work in the original NodeJS bindings")]
        public void CanFindButtonAsADescendentOfCentre()
        {
            // Ensure we really are finding the Descendant of a container by clicking the 'Live' button (Row 1)
            FlutterDriver.Click(
                FlutterBy.Descendant(
                    of: FlutterBy.ValueKey("rowContainingLiveButton"), 
                    matching: TapControl, 
                    matchRoot: true));

            FlutterDriver.GetText(FlutterBy.ValueKey("tapCounter")).Should().Be("1", because: "because a short tap will increase the counter by 1");

            // Ensure we really are finding the Descendant of a container by clicking the 'Dead' button (Row 2)
            FlutterDriver.Click(
                FlutterBy.Descendant(
                    of: FlutterBy.ValueKey("rowContainingDeadButton"),
                    matching: TapControl,
                    matchRoot: true));

            FlutterDriver.GetText(FlutterBy.ValueKey("tapCounter")).Should().Be("1", because: "because the matching button in Row 2 is dead and does not change the counter. ");
        }

        [TestMethod]
        [Ignore(message: "I cannot get relative locators work in the original NodeJS bindings")]
        public void CanFindAncestorLiveButton()
        {
            // Ensure we really are finding the Descendant of a container by clicking the 'Live' button (Row 1)
            FlutterDriver.Click(
                FlutterBy.Ancestor(
                    of: FlutterBy.Text("+100 (Find Ancestor - Live)"),
                    matching: FlutterBy.ValueKey("flatButtonLive100"),
                    matchRoot: true));

            FlutterDriver.GetText(FlutterBy.ValueKey("tapCounter")).Should().Be("100", because: "because a tap will increase the counter by 100");
        }
    }
}
