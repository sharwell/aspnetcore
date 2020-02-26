// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.E2ETesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Microsoft.AspNetCore.Components.E2ETest
{
    internal static class BasicTestAppWebDriverExtensions
    {
        public static IWebElement MountTestComponent<TComponent>(this IWebDriver browser) where TComponent : IComponent
        {
            var componentTypeName = typeof(TComponent).FullName;
            var testSelector = browser.WaitUntilTestSelectorReady();
            testSelector.SelectByValue("none");
            testSelector.SelectByValue(componentTypeName);
            return browser.FindElement(By.TagName("app"));
        }

        public static SelectElement WaitUntilTestSelectorReady(this IWebDriver browser)
        {
            var elemToFind = By.CssSelector("#test-selector > select");
            return new SelectElement(browser.Exists(elemToFind));
        }
    }
}
