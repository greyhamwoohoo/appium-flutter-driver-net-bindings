using Appium.Flutter.Finder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Appium.Flutter.SystemTests
{
    [TestClass]
    public class ScrollTests : TestBase
    {
        [TestMethod]
        public void ScrollIntoView_ObjectIsAlreadyInView()
        {
            var response = FlutterDriver.ExecuteScript("flutter:scrollIntoView", FlutterBy.Tooltip("Raise Me By 3").ToBase64(), new Dictionary<string, object>() 
            {
                { "alignment", 0.1 }
            });

            Assert.Fail("PENDING: TODO:");
        }
    }
}
