// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Rendering;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Microsoft.AspNetCore.Blazor.Hosting
{
    internal class WebAssemblyBlazorApplicationBuilder : IComponentsApplicationBuilder
    {
        public WebAssemblyBlazorApplicationBuilder(IServiceProvider services)
        {
            Entries = new List<(Type componentType, string domElementSelector)>();
            Services = services;
        }

        public List<(Type componentType, string domElementSelector)> Entries { get; }

        public IServiceProvider Services { get; }

        public void AddComponent(Type componentType, string domElementSelector)
        {
            if (componentType == null)
            {
                throw new ArgumentNullException(nameof(componentType));
            }

            if (domElementSelector == null)
            {
                throw new ArgumentNullException(nameof(domElementSelector));
            }

            Entries.Add((componentType, domElementSelector));
        }

        public async Task<WebAssemblyRenderer> CreateRendererAsync()
        {
            var loggerFactory = (ILoggerFactory)Services.GetService(typeof(ILoggerFactory));
            var renderer = new WebAssemblyRenderer(Services, loggerFactory);
            for (var i = 0; i < Entries.Count; i++)
            {
                var (componentType, domElementSelector) = Entries[i];
                await renderer.AddComponentAsync(componentType, domElementSelector);
            }

            return renderer;
        }
    }
}
