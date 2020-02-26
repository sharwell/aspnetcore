// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Components;
using Mono.WebAssembly.Interop;

namespace Microsoft.AspNetCore.Blazor.Services
{
    internal sealed class WebAssemblyJSRuntime : MonoWebAssemblyJSRuntime
    {
        private static readonly WebAssemblyJSRuntime _instance = new WebAssemblyJSRuntime();
        private static bool _initialized;

        public WebAssemblyJSRuntime()
        {
            JsonSerializerOptions.Converters.Add(new ElementReferenceJsonConverter());
        }

        public static WebAssemblyJSRuntime Instance
        {
            get
            {
                if (!_initialized)
                {
                    // This is executing in MonoWASM. Consequently we do not to have concern ourselves with thread safety.
                    _initialized = true;
                    Initialize(_instance);
                }

                return _instance;
            }
        }
    }
}
