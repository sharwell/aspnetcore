// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Blazor.Hosting
{
    internal interface IBlazorStartup
    {
        void ConfigureServices(IServiceCollection services);

        void Configure(IComponentsApplicationBuilder app, IServiceProvider services);
    }
}
