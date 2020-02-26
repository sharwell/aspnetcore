// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Routing;
using Interop = Microsoft.AspNetCore.Components.Web.BrowserNavigationManagerInterop;

namespace Microsoft.AspNetCore.Blazor.Services
{
    internal sealed class WebAssemblyNavigationInterception : INavigationInterception
    {
        public static readonly WebAssemblyNavigationInterception Instance = new WebAssemblyNavigationInterception();

        public Task EnableNavigationInterceptionAsync()
        {
            WebAssemblyJSRuntime.Instance.Invoke<object>(Interop.EnableNavigationInterception);
            return Task.CompletedTask;
        }
    }
}
