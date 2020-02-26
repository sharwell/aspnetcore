// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Http.Connections
{
    public class ConnectionOptionsSetup : IConfigureOptions<ConnectionOptions>
    {
        public static TimeSpan DefaultDisconectTimeout = TimeSpan.FromSeconds(15);

        public void Configure(ConnectionOptions options)
        {
            if (options.DisconnectTimeout == null)
            {
                options.DisconnectTimeout = DefaultDisconectTimeout;
            }
        }
    }
}
