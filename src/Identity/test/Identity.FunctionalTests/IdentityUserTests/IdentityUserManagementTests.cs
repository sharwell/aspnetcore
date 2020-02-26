// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Identity.DefaultUI.WebSite;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Microsoft.AspNetCore.Identity.FunctionalTests.IdentityUserTests
{
    public class IdentityUserManagementTests : ManagementTests<Startup, IdentityDbContext>
    {
        public IdentityUserManagementTests(ServerFactory<Startup, IdentityDbContext> serverFactory) : base(serverFactory)
        {
        }
    }
}
