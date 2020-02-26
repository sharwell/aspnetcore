// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Blazor.Hosting
{
    /// <summary>
    /// Context containing the common services on the <see cref="IWebAssemblyHost" />. Some properties may be null until set by the <see cref="IWebAssemblyHost" />.
    /// </summary>
    public sealed class WebAssemblyHostBuilderContext
    {
        /// <summary>
        /// Creates a new <see cref="WebAssemblyHostBuilderContext" />.
        /// </summary>
        /// <param name="properties">The property collection.</param>
        public WebAssemblyHostBuilderContext(IDictionary<object, object> properties)
        {
            Properties = properties ?? throw new System.ArgumentNullException(nameof(properties));
        }

        /// <summary>
        /// A central location for sharing state between components during the host building process.
        /// </summary>
        public IDictionary<object, object> Properties { get; }
    }
}