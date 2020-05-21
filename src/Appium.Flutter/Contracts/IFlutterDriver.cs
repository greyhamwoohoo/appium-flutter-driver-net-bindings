using Appium.Flutter.Finder;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System.Collections.Generic;

namespace Appium.Flutter.Contracts
{
    public interface IFlutterDriver : IWrapsDriver
    {
        string CheckHealth();
        void ClearTimeline();
        object ExecuteScript(string script, params object[] args);
        void ForceGC();
        string GetRenderTree();
        string GetElementText(FlutterBy by);
        void Click(FlutterBy by);
        long GetSemanticsId(FlutterBy by);
        Dictionary<string, object> GetRenderObjectDiagnostics(FlutterBy by, bool includeProperties = true, int subtreeDepth = 2);
    }
}
