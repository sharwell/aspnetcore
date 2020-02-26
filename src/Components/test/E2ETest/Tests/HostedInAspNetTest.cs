// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Components.E2ETest.Infrastructure;
using Microsoft.AspNetCore.Components.E2ETest.Infrastructure.ServerFixtures;
using Microsoft.AspNetCore.E2ETesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.AspNetCore.Components.E2ETest.Tests
{
    public class HostedInAspNetTest : ServerTestBase<AspNetSiteServerFixture>
    {
        public HostedInAspNetTest(
            BrowserFixture browserFixture,
            AspNetSiteServerFixture serverFixture,
            ITestOutputHelper output)
            : base(browserFixture, serverFixture, output)
        {
            serverFixture.BuildWebHostMethod = HostedInAspNet.Server.Program.BuildWebHost;
            serverFixture.Environment = AspNetEnvironment.Development;
        }

        protected override void InitializeAsyncCore()
        {
            Navigate("/", noReload: true);
            WaitUntilLoaded();
        }

        [Fact]
        public void HasTitle()
        {
            Assert.Equal("Sample Blazor app", Browser.Title);
        }

        [Fact]
        public void ServesStaticAssetsFromClientAppWebRoot()
        {
            var javascriptExecutor = (IJavaScriptExecutor)Browser;
            var bootstrapTooltipType = javascriptExecutor
                .ExecuteScript("return window.customJsWasLoaded;");
            Assert.True((bool)bootstrapTooltipType);
        }

        private void WaitUntilLoaded()
        {
            new WebDriverWait(Browser, TimeSpan.FromSeconds(30)).Until(
                driver => driver.FindElement(By.TagName("app")).Text != "Loading...");
        }
    }
}
