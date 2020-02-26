﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics.Tracing;
using System.Reflection;
using Xunit;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Tests
{
    public class KestrelEventSourceTests
    {
        [Fact]
        public void ExistsWithCorrectId()
        {
            var esType = typeof(KestrelServer).GetTypeInfo().Assembly.GetType(
                "Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure.KestrelEventSource",
                throwOnError: true,
                ignoreCase: false
            );

            Assert.NotNull(esType);

            Assert.Equal("Microsoft-AspNetCore-Server-Kestrel", EventSource.GetName(esType));
            Assert.Equal(Guid.Parse("bdeb4676-a36e-5442-db99-4764e2326c7d"), EventSource.GetGuid(esType));
            Assert.NotEmpty(EventSource.GenerateManifest(esType, "assemblyPathToIncludeInManifest"));
        }
    }
}
