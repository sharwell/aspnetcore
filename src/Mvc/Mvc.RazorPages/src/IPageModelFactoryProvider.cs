// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.RazorPages
{
    /// <summary>
    /// Provides methods for creation and disposal of Razor Page models.
    /// </summary>
    public interface IPageModelFactoryProvider
    {
        /// <summary>
        /// Creates a factory for producing models for Razor Pages given the specified <see cref="PageContext"/>.
        /// </summary>
        /// <param name="descriptor">The <see cref="CompiledPageActionDescriptor"/>.</param>
        /// <returns>The Razor Page model factory.</returns>
        Func<PageContext, object> CreateModelFactory(CompiledPageActionDescriptor descriptor);

        /// <summary>
        /// Releases a Razor Page model.
        /// </summary>
        /// <param name="descriptor">The <see cref="CompiledPageActionDescriptor"/>.</param>
        /// <returns>The delegate used to release the created Razor Page model.</returns>
        Action<PageContext, object> CreateModelDisposer(CompiledPageActionDescriptor descriptor);
    }
}