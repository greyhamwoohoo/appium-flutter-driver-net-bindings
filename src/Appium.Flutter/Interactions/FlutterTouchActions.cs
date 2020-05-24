using Appium.Flutter.Finder;
using Appium.Flutter.Interactions.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Appium.Flutter.Interactions
{
    public class FlutterTouchActions : IFlutterTouchActions
    {
        protected List<Dictionary<string, object>> Actions { get; }

        public FlutterTouchActions()
        {
            Actions = new List<Dictionary<string, object>>();
        }

        public IFlutterTouchActions Tap(FlutterBy by)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));

            Actions.Add(new Dictionary<string, object>()
            {
                {  "action", "tap" },
                { "options", new Dictionary<string, object>()
                    {
                    { "element", by.ToBase64() }
                    }
                }
            });

            return this;
        }

        public IFlutterTouchActions LongPress(FlutterBy by)
        {
            if (null == by) throw new System.ArgumentNullException(nameof(by));

            Actions.Add(new Dictionary<string, object>()
            {
                {  "action", "longPress" },
                { "options", new Dictionary<string, object>()
                    {
                    { "element", by.ToBase64() }
                    }
                }
            });

            return this;
        }

        public ITouchAction ToTouchAction()
        {
            if (Actions.Count == 0) throw new System.InvalidOperationException($"No Actions have been specified. ");

            return ToTouchActions().First();
        }

        // Bit of a hack until I work out why the MultiPerform doesnt work
        public IEnumerable<ITouchAction> ToTouchActions()
        {
            // TODO: Should deep copy the properties
            return Actions.Select(action => new FlutterTouchAction(new List<Dictionary<string, object>>() { action }));
        }

        public bool IsMultiAction => Actions.Count > 1;

        /* These actions seem to have no effect on Flutter Apps: will investigate more
         public IFlutterTouchActions Press(FlutterBy by)
         {
             if (null == by) throw new System.ArgumentNullException(nameof(by));

             Actions.Add(new Dictionary<string, object>()
             {
                 {  "action", "press" },
                 { "options", new Dictionary<string, object>()
                     {
                     { "element", by.ToBase64() }
                     }
                 }
             });

             return this;
         }

         public IFlutterTouchActions Wait(int milliSeconds)
         {
             Actions.Add(new Dictionary<string, object>()
             {
                 {  "action", "wait" },
                 { "options", new Dictionary<string, object>()
                     {
                     { "ms", milliSeconds }
                     }
                 }
             });

             return this;
         }

         public IFlutterTouchActions Release()
         {
             Actions.Add(new Dictionary<string, object>()
             {
                 {  "action", "release" }
             });

             return this;
         }
         */

        private class FlutterTouchAction : ITouchAction
        {
            protected List<Dictionary<string, object>> Actions { get; }

            public FlutterTouchAction(List<Dictionary<string, object>> actions)
            {
                Actions = actions ?? throw new System.ArgumentNullException(nameof(actions)); ;
            }

            public void Cancel()
            {
                throw new System.NotImplementedException();
            }

            public List<Dictionary<string, object>> GetParameters()
            {
                return Actions;
            }

            public ITouchAction LongPress(IWebElement el, double? x = null, double? y = null)
            {
                throw new System.NotImplementedException();
            }

            public ITouchAction LongPress(double x, double y)
            {
                throw new System.NotImplementedException();
            }

            public ITouchAction MoveTo(IWebElement element, double? x = null, double? y = null)
            {
                throw new System.NotImplementedException();
            }

            public ITouchAction MoveTo(double x, double y)
            {
                throw new System.NotImplementedException();
            }

            public void Perform()
            {
                throw new System.NotImplementedException();
            }

            public ITouchAction Press(IWebElement element, double? x = null, double? y = null)
            {
                throw new System.NotImplementedException();
            }

            public ITouchAction Press(double x, double y)
            {
                throw new System.NotImplementedException();
            }

            public ITouchAction Release()
            {
                throw new System.NotImplementedException();
            }

            public ITouchAction Tap(IWebElement element, double? x = null, double? y = null, long? count = null)
            {
                throw new System.NotImplementedException();
            }

            public ITouchAction Tap(double x, double y, long? count = null)
            {
                throw new System.NotImplementedException();
            }

            public ITouchAction Wait(long? ms = null)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
