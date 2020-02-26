﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc.RazorPages
{
    /// <summary>
    /// Provides methods to create a Razor page.
    /// </summary>
    public interface IPageActivatorProvider
    {
        /// <summary>
        /// Creates a Razor page activator.
        /// </summary>
        /// <param name="descriptor">The <see cref="CompiledPageActionDescriptor"/>.</param>
        /// <returns>The delegate used to activate the page.</returns>
        Func<PageContext, ViewContext, object> CreateActivator(CompiledPageActionDescriptor descriptor);

        /// <summary>
        /// Releases a Razor page.
        /// </summary>
        /// <param name="descriptor">The <see cref="CompiledPageActionDescriptor"/>.</param>
        /// <returns>The delegate used to dispose the activated page.</returns>
        Action<PageContext, ViewContext, object> CreateReleaser(CompiledPageActionDescriptor descriptor);
    }
}