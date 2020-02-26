// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using BasicTestApp;
using Microsoft.AspNetCore.E2ETesting;
using Microsoft.AspNetCore.Components.E2ETest.Infrastructure;
using Microsoft.AspNetCore.Components.E2ETest.Infrastructure.ServerFixtures;
using OpenQA.Selenium;
using Xunit.Abstractions;
using Xunit;

namespace Microsoft.AspNetCore.Components.E2ETest.Tests
{
    public class StartupErrorNotificationTest : ServerTestBase<DevHostServerFixture<Program>>
    {
        public StartupErrorNotificationTest(
            BrowserFixture browserFixture,
            DevHostServerFixture<Program> serverFixture,
            ITestOutputHelper output)
            : base(browserFixture, serverFixture, output)
        {
            _serverFixture.PathBase = ServerPathBase;
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void DisplaysNotificationForStartupException(bool errorIsAsync)
        {
            var url = $"{ServerPathBase}?error={(errorIsAsync ? "async" : "sync")}";

            Navigate(url, noReload: true);
            var errorUiElem = Browser.Exists(By.Id("blazor-error-ui"), TimeSpan.FromSeconds(10));
            Assert.NotNull(errorUiElem);

            Browser.Equal("block", () => errorUiElem.GetCssValue("display"));
        }
    }
}
