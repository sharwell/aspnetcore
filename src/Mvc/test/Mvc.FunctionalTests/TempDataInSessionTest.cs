// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net.Http;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.FunctionalTests
{
    public class TempDataInSessionTest : TempDataTestBase, IClassFixture<MvcTestFixture<BasicWebSite.StartupWithSessionTempDataProvider>>
    {
        public TempDataInSessionTest(MvcTestFixture<BasicWebSite.StartupWithSessionTempDataProvider> fixture)
        {
            Client = fixture.CreateDefaultClient();
        }

        protected override HttpClient Client { get; }
    }
}