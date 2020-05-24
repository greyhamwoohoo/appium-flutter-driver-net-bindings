using FluentAssertions;
using GreyhamWooHoo.Flutter.Finder;
using GreyhamWooHoo.Flutter.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreyhamWooHoo.Flutter.SystemTests
{
    [TestClass]
    public class TapsTests : TestBase
    {
        protected FlutterBy TapControl = FlutterBy.Text("FUT:+1 (tap), +10 (long tap)");

        [TestInitialize]
        public void NavigateToTextTestPage()
        {
            FlutterDriver.Click(FlutterBy.Text("Navigate to Taps Test Page"));

            FlutterDriver.WaitFor(FlutterBy.Text("Taps Page"));

            FlutterDriver.GetText(FlutterBy.ValueKey("tapCounter")).Should().Be("0", because: "the counter is initially 0");
        }

        [TestMethod]
        public void Tap()
        {
            var touchActions = new FlutterTouchActions().Tap(TapControl);

            FlutterDriver.Perform(touchActions);

            FlutterDriver.GetText(FlutterBy.ValueKey("tapCounter")).Should().Be("1", because: "because a short tap will increase the counter by 1");
        }

        [TestMethod]
        public void LongPress()
        {
            var touchActions = new FlutterTouchActions().LongPress(TapControl);

            FlutterDriver.Perform(touchActions);

            FlutterDriver.GetText(FlutterBy.ValueKey("tapCounter")).Should().Be("10", because: "because a long press will increase the counter by 10");
        }

        [TestMethod]
        public void ShortAndLongPress()
        {
            var touchActions = new FlutterTouchActions().Tap(TapControl).LongPress(TapControl);

            FlutterDriver.Perform(touchActions);

            FlutterDriver.GetText(FlutterBy.ValueKey("tapCounter")).Should().Be("11", because: "because a tap and long press will increase the counter by 11 (1 + 10)");
        }

        [TestMethod]
        public void ShortPress_Primitives()
        {
            // This is disable at the moment - sending commands like 'press', 'wait' and 'release' appear to have no effect. 
            /*
            var touchActions = new FlutterTouchActions()
                .Press(TapControl)
                .Wait(100)
                .Release();

            FlutterDriver.Perform(touchActions);

            FlutterDriver.GetText(FlutterBy.ValueKey("tapCounter")).Should().Be("1", because: "we have simulated a short tap with press, wait 100ms, release");
            */
        }
    }
}
