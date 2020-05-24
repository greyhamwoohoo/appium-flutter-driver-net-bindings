using Appium.Flutter.Finder;
using OpenQA.Selenium.Appium.Interfaces;
using System.Collections.Generic;

namespace Appium.Flutter.Interactions.Contracts
{
    public interface IFlutterTouchActions
    {
        IFlutterTouchActions Tap(FlutterBy element);
        IFlutterTouchActions LongPress(FlutterBy element);
        bool IsMultiAction { get; }
        ITouchAction ToTouchAction();
        IEnumerable<ITouchAction> ToTouchActions();

        // These actions seem to have no effect on Flutter Apps: will investigate more
        // IFlutterTouchActions Press(FlutterBy element);
        // IFlutterTouchActions Wait(int milliSeconds);
        // IFlutterTouchActions Release();
    }
}
