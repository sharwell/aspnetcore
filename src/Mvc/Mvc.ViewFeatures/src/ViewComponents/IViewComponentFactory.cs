// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.ViewComponents
{
    /// <summary>
    /// Provides methods for creation and disposal of view components.
    /// </summary>
    public interface IViewComponentFactory
    {
        /// <summary>
        /// Creates a new controller for the specified <paramref name="context"/>.
        /// </summary>
        /// <param name="context"><see cref="ViewComponentContext"/> for the view component.</param>
        /// <returns>The view component.</returns>
        object CreateViewComponent(ViewComponentContext context);

        /// <summary>
        /// Releases a view component instance.
        /// </summary>
        /// <param name="context">The context associated with the <paramref name="component"/>.</param>
        /// <param name="component">The view component.</param>
        void ReleaseViewComponent(ViewComponentContext context, object component);
    }
}
