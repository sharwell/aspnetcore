// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Identity.DefaultUI.WebSite;
using Identity.DefaultUI.WebSite.Data;

namespace Microsoft.AspNetCore.Identity.FunctionalTests.IdentityUserTests
{
    public class Bootstrap3AuthorizationTests : AuthorizationTests<ApplicationUserStartup, ApplicationDbContext>
    {
        public Bootstrap3AuthorizationTests(ServerFactory<ApplicationUserStartup, ApplicationDbContext> serverFactory) : base(serverFactory)
        {
            serverFactory.BootstrapFrameworkVersion = "V3";
        }
    }
}
