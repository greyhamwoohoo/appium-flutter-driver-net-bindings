namespace Appium.Flutter
{
    public interface IFlutterDriver
    {
        object ExecuteScript(string script, params object[] args);
        string CheckHealth();
    }
}
