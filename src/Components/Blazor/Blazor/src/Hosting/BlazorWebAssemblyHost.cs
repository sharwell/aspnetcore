// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Blazor.Hosting
{
    /// <summary>
    /// Used to create an instance of Blazor host builder for a Browser application.
    /// </summary>
    public static class BlazorWebAssemblyHost
    {
        /// <summary>
        /// Creates an instance of <see cref="IWebAssemblyHostBuilder"/>.
        /// </summary>
        /// <returns>The <see cref="IWebAssemblyHostBuilder"/>.</returns>
        public static IWebAssemblyHostBuilder CreateDefaultBuilder()
        {
            return new WebAssemblyHostBuilder();
        }
    }
}
