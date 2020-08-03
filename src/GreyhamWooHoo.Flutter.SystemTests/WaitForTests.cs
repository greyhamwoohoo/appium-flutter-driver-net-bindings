using FluentAssertions;
using GreyhamWooHoo.Flutter.Finder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreyhamWooHoo.Flutter.SystemTests
{
    [TestClass]
    public class WaitForTests : TestBase
    {
        protected FlutterBy ControlThatAlwaysExists = FlutterBy.Text("FUT: FlutterBy.Text (Increment 1)");
        protected FlutterBy ControlThatNeverExists = FlutterBy.Text("woo");

        [TestInitialize]
        public void NavigateToFindersPage()
        {
            FlutterDriver.Click(FlutterBy.Text("Navigate to Finders and Position Test Page"));
        }

        [TestMethod]
        public void WaitFor_ByScript()
        {
            // TODO: Better exception
            FlutterDriver.ExecuteScript("flutter:waitFor", ControlThatAlwaysExists.ToBase64());
        }

        [TestMethod]
        public void WaitFor_NeverExists_ByScript()
        {
            // TODO: Better exception
            try
            {
                FlutterDriver.ExecuteScript("flutter:waitFor", ControlThatNeverExists.ToBase64(), 1);

                Assert.Fail($"We should never see this statement - the control being searched for ALWAYS EXISTS; so an exception should have been thrown. ");
            }
            catch (OpenQA.Selenium.WebDriverException ex)
            {
                ex.Message.Should().Contain("Timeout while executing waitFor");
            }
        }

        [TestMethod]
        public void WaitFor_Driver()
        {
            // TODO: Better exception
            FlutterDriver.WaitFor(ControlThatAlwaysExists);
        }

        [TestMethod]
        public void WaitFor_NeverExists_Driver()
        {
            // TODO: Better exception
            try
            {
                FlutterDriver.WaitFor(ControlThatNeverExists, 1);

                Assert.Fail($"We should never see this statement - the control being searched for ALWAYS EXISTS; so an exception should have been thrown. ");
            }
            catch (OpenQA.Selenium.WebDriverException ex)
            {
                ex.Message.Should().Contain("Timeout while executing waitFor");
            }
        }

        [TestMethod]
        public void WaitForAbsent_NeverExists_ByScript()
        {
            // HACK: On my own box, there is no issue - but when I run this on the CI/CD I get the following error:
            /*
                Test method GreyhamWooHoo.Flutter.SystemTests.WaitForTests.WaitForAbsent_NeverExists_ByScript threw exception:
                OpenQA.Selenium.WebDriverException: An unknown server-side error occurred while processing the command. Original error: Cannot execute command waitForAbsent, server reponse {
                "isError": true,
                "response": "Timeout while executing waitForAbsent: TimeoutException after 0:00:01.000000: Future not completed\n",
                "type": "_extensionType",
                "method": "ext.flutter.driver"
                } */

            // To get around this, I wait for the page to 'converge' first
            FlutterDriver.WaitFor(ControlThatAlwaysExists);

            // NOTE: The final parameter is in SECONDS
            FlutterDriver.ExecuteScript("flutter:waitForAbsent", ControlThatNeverExists.ToBase64(), 1);
        }

        [TestMethod]
        public void WaitForAbsent_ExistsForFailQuickly_ByScript()
        {
            try
            {
                // NOTE: The final parameter is in SECONDS
                FlutterDriver.ExecuteScript("flutter:waitForAbsent", ControlThatAlwaysExists.ToBase64(), 1);

                Assert.Fail($"We should never see this statement - the control being searched for ALWAYS EXISTS; so an exception should have been thrown. ");
            }
            catch(OpenQA.Selenium.WebDriverException ex)
            {
                ex.Message.Should().Contain("Timeout while executing waitForAbsent");
            }
        }

        [TestMethod]
        public void WaitForAbsent_NeverExists_ByDriver()
        {
            FlutterDriver.WaitForAbsent(ControlThatNeverExists);
        }

        [TestMethod]
        public void WaitForAbsent_ExistsForFailQuickly_ByDriver()
        {
            try
            {
                FlutterDriver.WaitForAbsent(ControlThatAlwaysExists, timeoutInSeconds: 1);

                Assert.Fail($"We should never see this statement - the control being searched for ALWAYS EXISTS; so an exception should have been thrown. ");
            }
            catch (OpenQA.Selenium.WebDriverException ex)
            {
                ex.Message.Should().Contain("Timeout while executing waitForAbsent");
            }
        }
    }
}
