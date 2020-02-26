// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TestStartupAssembly1.TestHostingStartup1))]

namespace TestStartupAssembly1
{
    public class TestHostingStartup1 : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.UseSetting("testhostingstartup1", "1");
            builder.UseSetting("testhostingstartup_chain", builder.GetSetting("testhostingstartup_chain") + "1");
        }
    }
}
