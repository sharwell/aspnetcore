﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.RazorPages
{
    /// <summary>
    /// Provides methods to create a Razor Page model.
    /// </summary>
    public interface IPageModelActivatorProvider
    {
        /// <summary>
        /// Creates a Razor Page model activator.
        /// </summary>
        /// <param name="descriptor">The <see cref="CompiledPageActionDescriptor"/>.</param>
        /// <returns>The delegate used to activate the page model.</returns>
        Func<PageContext, object> CreateActivator(CompiledPageActionDescriptor descriptor);

        /// <summary>
        /// Releases a Razor Page model.
        /// </summary>
        /// <param name="descriptor">The <see cref="CompiledPageActionDescriptor"/>.</param>
        /// <returns>The delegate used to dispose the activated Razor Page model.</returns>
        Action<PageContext, object> CreateReleaser(CompiledPageActionDescriptor descriptor);
    }
}