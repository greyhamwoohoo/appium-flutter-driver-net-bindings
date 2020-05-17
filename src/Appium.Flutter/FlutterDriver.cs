using Appium.Flutter.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;

namespace Appium.Flutter
{
    public class FlutterDriver : IFlutterDriver, IWrapsDriver
    {
        protected ICommandExecutor CommandExecution { get; }

        public IWebDriver WrappedDriver { get; }

        public FlutterDriver(IWebDriver driver, ICommandExecutor commandExecutor)
        {
            if (null == driver) throw new System.ArgumentNullException(nameof(driver));
            if (null == commandExecutor) throw new System.ArgumentNullException(nameof(commandExecutor));

            WrappedDriver = driver;
            CommandExecution = commandExecutor;
        }

        public object ExecuteScript(string script, params object[] args)
        {
            var javascriptExecutor = WrappedDriver as IJavaScriptExecutor;
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
