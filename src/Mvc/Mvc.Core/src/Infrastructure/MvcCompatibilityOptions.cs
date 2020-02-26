// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    /// <summary>
    /// An options type for configuring the application <see cref="Mvc.CompatibilityVersion"/>.
    /// </summary>
    /// <remarks>
    /// The primary way to configure the application's <see cref="Mvc.CompatibilityVersion"/> is by
    /// calling <see cref="MvcCoreMvcBuilderExtensions.SetCompatibilityVersion(IMvcBuilder, CompatibilityVersion)"/>
    /// or <see cref="MvcCoreMvcCoreBuilderExtensions.SetCompatibilityVersion(IMvcCoreBuilder, CompatibilityVersion)"/>.
    /// </remarks>
    public class MvcCompatibilityOptions
    {
        /// <summary>
        /// Gets or sets the application's configured <see cref="Mvc.CompatibilityVersion"/>.
        /// </summary>
        /// <value>the default value is <see cref="CompatibilityVersion.Version_3_0"/>.</value>
        public CompatibilityVersion CompatibilityVersion { get; set; } = CompatibilityVersion.Version_3_0;
    }
}
