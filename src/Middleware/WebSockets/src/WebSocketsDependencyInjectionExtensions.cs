// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.WebSockets
{
    public static class WebSocketsDependencyInjectionExtensions
    {
        public static IServiceCollection AddWebSockets(this IServiceCollection services, Action<WebSocketOptions> configure)
        {
            return services.Configure(configure);
        }
    }
}
