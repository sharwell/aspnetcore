// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Internal;
using Microsoft.AspNetCore.Testing;

namespace Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Tests.TestHelpers
{
    internal class TestLibuvTransportContext : LibuvTransportContext
    {
        public TestLibuvTransportContext()
        {
            var logger = new TestApplicationErrorLogger();

            AppLifetime = new LifetimeNotImplemented();
            Log = new LibuvTrace(logger);
            Options = new LibuvTransportOptions { ThreadCount = 1 };
        }
    }
}
