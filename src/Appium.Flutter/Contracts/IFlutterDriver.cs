using Appium.Flutter.Finder;
using System.Collections.Generic;

namespace Appium.Flutter.Contracts
{
    public interface IFlutterDriver
    {
        string CheckHealth();
        void ClearTimeline();
        object ExecuteScript(string script, params object[] args);
        void ForceGC();
        string GetRenderTree();
        string GetElementText(FlutterBy by);
        Dictionary<string, object> GetRenderObjectDiagnostics(FlutterBy by, bool includeProperties = true, int subtreeDepth = 2);
    }
}
