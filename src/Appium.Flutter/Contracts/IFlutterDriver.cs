namespace Appium.Flutter.Contracts
{
    public interface IFlutterDriver
    {
        string CheckHealth();
        void ClearTimeline();
        object ExecuteScript(string script, params object[] args);
        void ForceGC();
        string GetRenderTree();
    }
}
