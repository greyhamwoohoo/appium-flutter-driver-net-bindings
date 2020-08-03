using GreyhamWooHoo.Flutter.Contracts;
using GreyhamWooHoo.Flutter.Finder;
using GreyhamWooHoo.Flutter.Interactions.Contracts;
using GreyhamWooHoo.Flutter.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GreyhamWooHoo.Flutter
{
    public class FlutterDriver : IFlutterDriver, IWrapsDriver
    {
        protected SessionId SessionId { get; }
        protected ICommandExecutor CommandExecutor { get; }
        protected int ElementTimeoutInSeconds { get; }

        public IWebDriver WrappedDriver { get; }

        public FlutterDriver(RemoteWebDriver driver, ICommandExecutor commandExecutor, int elementTimeoutInSeconds)
        {
            WrappedDriver = driver ?? throw new System.ArgumentNullException(nameof(driver));
            CommandExecutor = commandExecutor ?? throw new System.ArgumentNullException(nameof(commandExecutor));
            SessionId = driver.SessionId;
            ElementTimeoutInSeconds = elementTimeoutInSeconds;
        }

        public object ExecuteScript(string script, params object[] args)
        {
            if (args == null) args = new object[0];

            var javascriptExecutor = WrappedDriver as IJavaScriptExecutor;
            if (null == javascriptExecutor) throw new InvalidOperationException($"The WebDriver does not support Javascript Execution. ");

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

        public void Click(FlutterBy by)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));

            var response = Execute(DriverCommand.ClickElement, new Dictionary<string, object>()
            {
                { "id", by.ToBase64() }
            });
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

        public string GetText(FlutterBy by)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));

            var response = Execute(DriverCommand.GetElementText, new Dictionary<string, object>()
            {
                { "id", by.ToBase64() }
            });

            return $"{response.Value}";
        }

        public long GetSemanticsId(FlutterBy by)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));

            var response = ExecuteScript("flutter:getSemanticsId", by.ToBase64());

            return ((long)response);
        }

        #region Mostly lifted from RemoteWebDriver

        /// <summary>
        /// Based on RemoteWebDriver. 
        /// </summary>
        /// <returns></returns>
        protected Response Execute(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            Command commandToExecute = new Command(SessionId, driverCommandToExecute, parameters);

            Response commandResponse;

            try
            {
                commandResponse = CommandExecutor.Execute(commandToExecute);
            }
            catch (System.Net.WebException e)
            {
                commandResponse = new Response
                {
                    Status = WebDriverResult.UnhandledError,
                    Value = e
                };
            }
            catch(Exception ex)
            {
                throw;
            }

            if(commandResponse.Status != WebDriverResult.Success)
            {
                UnpackAndThrowOnError(commandResponse);
            }

            return commandResponse;
        }

        /// <summary>
        /// Copied almost verbatim from RemoteWebDriver. 
        /// </summary>
        /// <param name="errorResponse"></param>
        private void UnpackAndThrowOnError(Response errorResponse)
        {
            // Check the status code of the error, and only handle if not success.
            if (errorResponse.Status != WebDriverResult.Success)
            {
                Dictionary<string, object> errorAsDictionary = errorResponse.Value as Dictionary<string, object>;
                if (errorAsDictionary != null)
                {
                    ErrorResponse errorResponseObject = new ErrorResponse(errorAsDictionary);
                    string errorMessage = errorResponseObject.Message;
                    switch (errorResponse.Status)
                    {
                        case WebDriverResult.NoSuchElement:
                            throw new NoSuchElementException(errorMessage);

                        case WebDriverResult.NoSuchFrame:
                            throw new NoSuchFrameException(errorMessage);

                        case WebDriverResult.UnknownCommand:
                            throw new NotImplementedException(errorMessage);

                        case WebDriverResult.ObsoleteElement:
                            throw new StaleElementReferenceException(errorMessage);

                        case WebDriverResult.ElementClickIntercepted:
                            throw new ElementClickInterceptedException(errorMessage);

                        case WebDriverResult.ElementNotInteractable:
                            throw new ElementNotInteractableException(errorMessage);

                        case WebDriverResult.ElementNotDisplayed:
                            throw new ElementNotVisibleException(errorMessage);

                        case WebDriverResult.InvalidElementState:
                        case WebDriverResult.ElementNotSelectable:
                            throw new InvalidElementStateException(errorMessage);

                        case WebDriverResult.UnhandledError:
                            throw new WebDriverException(errorMessage);

                        case WebDriverResult.NoSuchDocument:
                            throw new NoSuchElementException(errorMessage);

                        case WebDriverResult.Timeout:
                            throw new WebDriverTimeoutException(errorMessage);

                        case WebDriverResult.NoSuchWindow:
                            throw new NoSuchWindowException(errorMessage);

                        case WebDriverResult.InvalidCookieDomain:
                            throw new InvalidCookieDomainException(errorMessage);

                        case WebDriverResult.UnableToSetCookie:
                            throw new UnableToSetCookieException(errorMessage);

                        case WebDriverResult.AsyncScriptTimeout:
                            throw new WebDriverTimeoutException(errorMessage);

                        case WebDriverResult.UnexpectedAlertOpen:
                            // TODO(JimEvans): Handle the case where the unexpected alert setting
                            // has been set to "ignore", so there is still a valid alert to be
                            // handled.
                            string alertText = string.Empty;
                            if (errorAsDictionary.ContainsKey("alert"))
                            {
                                Dictionary<string, object> alertDescription = errorAsDictionary["alert"] as Dictionary<string, object>;
                                if (alertDescription != null && alertDescription.ContainsKey("text"))
                                {
                                    alertText = alertDescription["text"].ToString();
                                }
                            }
                            else if (errorAsDictionary.ContainsKey("data"))
                            {
                                Dictionary<string, object> alertData = errorAsDictionary["data"] as Dictionary<string, object>;
                                if (alertData != null && alertData.ContainsKey("text"))
                                {
                                    alertText = alertData["text"].ToString();
                                }
                            }

                            throw new UnhandledAlertException(errorMessage, alertText);

                        case WebDriverResult.NoAlertPresent:
                            throw new NoAlertPresentException(errorMessage);

                        case WebDriverResult.InvalidSelector:
                            throw new InvalidSelectorException(errorMessage);

                        case WebDriverResult.NoSuchDriver:
                            throw new WebDriverException(errorMessage);

                        default:
                            throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "{0} ({1})", errorMessage, errorResponse.Status));
                    }
                }
                else
                {
                    throw new WebDriverException("Unexpected error. " + errorResponse.Value.ToString());
                }
            }
        }

        public Dictionary<string, object> GetRenderObjectDiagnostics(FlutterBy by, bool includeProperties = true, int subtreeDepth = 2)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));

            var raw = ExecuteScript("flutter:getRenderObjectDiagnostics", by.ToBase64(), new Dictionary<string, object>()
            {
                { "includeProperties", includeProperties },
                { "subtreeDepth", subtreeDepth }
            });

            var response = raw as Dictionary<string, object>;
            return response;
        }

        public Position GetBottomLeft(FlutterBy by)
        {
            return GetAndAssertPositionResult(by, "flutter:getBottomLeft");
        }

        public Position GetBottomRight(FlutterBy by)
        {
            return GetAndAssertPositionResult(by, "flutter:getBottomRight");
        }

        public Position GetTopLeft(FlutterBy by)
        {
            return GetAndAssertPositionResult(by, "flutter:getTopLeft");
        }

        public Position GetTopRight(FlutterBy by)
        {
            return GetAndAssertPositionResult(by, "flutter:getTopRight");
        }

        public Position GetCenter(FlutterBy by)
        {
            return GetAndAssertPositionResult(by, "flutter:getCenter");
        }

        public byte[] Screenshot()
        {
            var result = new byte[0];

            var response = Execute(DriverCommand.Screenshot, new Dictionary<string, object>()
            {
                { "id", SessionId.ToString() }
            });

            result = System.Convert.FromBase64String($"{response.Value}");

            return result;
        }

        public void Screenshot(string path)
        {
            if (null == path) throw new System.ArgumentNullException(nameof(path));

            if(System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            var response = Execute(DriverCommand.Screenshot, new Dictionary<string, object>()
            {
                { "id", SessionId.ToString() }
            });

            var result = System.Convert.FromBase64String($"{response.Value}");
            System.IO.File.WriteAllBytes(path, result);
        }

        public void WaitFor(FlutterBy by)
        {
            WaitFor(by, timeoutInSeconds: ElementTimeoutInSeconds);
        }

        public void WaitFor(FlutterBy by, int timeoutInSeconds)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));

            // TODO: Can we capture and forward on a more useful error message?
            ExecuteScript("flutter:waitFor", by.ToBase64(), timeoutInSeconds);
        }

        public void WaitForAbsent(FlutterBy by)
        {
            WaitForAbsent(by, ElementTimeoutInSeconds);
        }

        public void WaitForAbsent(FlutterBy by, int timeoutInSeconds)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));
            if (timeoutInSeconds < 0) throw new System.ArgumentOutOfRangeException(nameof(timeoutInSeconds), $"TimeoutInSeconds must be > 0");
            
            // TODO: Can we capture and forward on a more useful error message?
            ExecuteScript("flutter:waitForAbsent", by.ToBase64(), timeoutInSeconds);
        }

        public void SendKeys(FlutterBy by, string keys)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));
           
            Execute(DriverCommand.SendKeysToElement, new Dictionary<string, object>()
            {
                { "id", by.ToBase64() },
                { "text", keys }
            });
        }

        public void Clear(FlutterBy by)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));

            Execute(DriverCommand.ClearElement, new Dictionary<string, object>()
            {
                { "id", by.ToBase64() }
            });
        }

        public void Close()
        {
            throw new System.NotImplementedException($"Flutter Driver .Close() is not implemented. Call .Close and .Quit on the WrappedDriver yourself to control its lifetime. ");
        }

        public void Perform(IFlutterTouchActions actions)
        {
            if (null == actions) throw new ArgumentNullException(nameof(actions));

            var performTouchActions = WrappedDriver as IPerformsTouchActions;
            if (null == performTouchActions) throw new InvalidOperationException($"The WrappedDriver does not support the IPerformsTouchActions interface. Ensure the RemoteWebDriver passed to FlutterDriver implements that interface. ");

            if (actions.IsMultiAction)
            {
                /* For Reference:
                   PerformMultiAction throws NotImplementedException. 

                    var parameters = actions.ToTouchAction().GetParameters();

                    Execute(AppiumDriverCommand.PerformMultiAction, new Dictionary<String, object>() 
                    {
                        { "actions", parameters }
                    });
                */

                // Passing multiple actions to PerformTouchAction does not seem to execute any of them: so I am taking the crude approach here of issuing
                // one at a time. Not sure what the implications of this are in the upstream drivers. 
                var touchActions = actions.ToTouchActions();
                touchActions.ToList().ForEach(touchAction =>
                {
                    performTouchActions.PerformTouchAction(touchAction);
                });
            }
            else
            {
                performTouchActions.PerformTouchAction(actions.ToTouchAction());
            }
        }
        
        #endregion

        private Position GetAndAssertPositionResult(FlutterBy by, string position)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));

            var result = ExecuteScript(position, by.ToBase64()); ;
            if (result == null) throw new System.InvalidCastException($"Position APIs are expected to return a Dictionary<string, object> but returned null. ");

            var dictionary = result as Dictionary<string, object>;
            if (dictionary == null) throw new System.InvalidCastException($"Position APIs are expected to return a Dictionary<string, object> but instead returned type {result.GetType().FullName}");

            if (!dictionary.ContainsKey("dx") || !dictionary.ContainsKey("dy"))
            {
                throw new System.InvalidOperationException($"The response was of type Dictionary<string, object> but did not contain both a 'dx' and 'dy' property as expected. ");
            }

            dictionary.ToList().ForEach(pair =>
            {
                Console.WriteLine($"key: {pair.Key}, value: {pair.Value}");
            });

            return new Position(dx: System.Convert.ToDouble(dictionary["dx"]), dy: System.Convert.ToDouble(dictionary["dy"]));
        }
    }
}
