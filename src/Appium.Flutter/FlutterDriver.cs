using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Appium.Flutter
{
    public class FlutterDriver : IFlutterDriver
    {
        private readonly IWebDriver _driver;
        private readonly ICommandExecutor _commandExecutor;

        public FlutterDriver(IWebDriver driver, ICommandExecutor commandExecutor)
        {
            if (null == driver) throw new System.ArgumentNullException(nameof(driver));
            if (null == commandExecutor) throw new System.ArgumentNullException(nameof(commandExecutor));

            _driver = driver;
            _commandExecutor = commandExecutor;
        }
        public object ExecuteScript(string script, params object[] args)
        {
            var javascriptExecutor = _driver as IJavaScriptExecutor;
            if (null == javascriptExecutor) throw new System.InvalidOperationException($"The WebDriver does not support Javascript Execution. ");

            var result = javascriptExecutor.ExecuteScript(script, args);
            return result;
        }

        public string CheckHealth()
        {
            var result = ExecuteScript("flutter:checkHealth");
            return $"{result}";
        }

        public void ClearTimeline()
        {
            ExecuteScript("flutter:clearTimeline");
        }

        public void ForceGC()
        {
            ExecuteScript("flutter:forceGC");
        }

        public string GetRenderTree()
        {
            var result = ExecuteScript("flutter:getRenderTree");
            return $"{result}";
        }
    }
}
