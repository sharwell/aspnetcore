// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc.RazorPages
{
    /// <summary>
    /// Provides methods for creation and disposal of Razor pages.
    /// </summary>
    public interface IPageFactoryProvider
    {
        /// <summary>
        /// Creates a factory for producing Razor pages for the specified <see cref="PageContext"/>.
        /// </summary>
        /// <param name="descriptor">The <see cref="CompiledPageActionDescriptor"/>.</param>
        /// <returns>The Razor page factory.</returns>
        Func<PageContext, ViewContext, object> CreatePageFactory(CompiledPageActionDescriptor descriptor);

        /// <summary>
        /// Releases a Razor page.
        /// </summary>
        /// <param name="descriptor">The <see cref="CompiledPageActionDescriptor"/>.</param>
        /// <returns>The delegate used to release the created page.</returns>
        Action<PageContext, ViewContext, object> CreatePageDisposer(CompiledPageActionDescriptor descriptor);
    }
}