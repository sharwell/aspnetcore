// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Buffers;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.AspNetCore.Server.Kestrel.FunctionalTests
{
    public static class TransportSelector
    {
        public static IWebHostBuilder GetWebHostBuilder(Func<MemoryPool<byte>> memoryPoolFactory = null,
                                                        long? maxReadBufferSize = null)
        {
            return new WebHostBuilder().UseSockets(options =>
            {
                options.MemoryPoolFactory = memoryPoolFactory ?? options.MemoryPoolFactory;
                options.MaxReadBufferSize = maxReadBufferSize;
            });
        }
    }
}
