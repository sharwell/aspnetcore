// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Components.E2ETest.Infrastructure.ServerFixtures
{
    public class BasicTestAppServerSiteFixture<TStartup> : AspNetSiteServerFixture where TStartup : class
    {
        public BasicTestAppServerSiteFixture()
        {
            BuildWebHostMethod = TestServer.Program.BuildWebHost<TStartup>;
        }
    }
}
