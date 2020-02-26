// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.Controllers
{
    /// <summary>
    /// Provides methods to create and release a controller.
    /// </summary>
    public interface IControllerFactoryProvider
    {
        /// <summary>
        /// Creates a factory for producing controllers for the specified <paramref name="descriptor"/>.
        /// </summary>
        /// <param name="descriptor">The <see cref="ControllerActionDescriptor"/>.</param>
        /// <returns>The controller factory.</returns>
        Func<ControllerContext, object> CreateControllerFactory(ControllerActionDescriptor descriptor);

        /// <summary>
        /// Releases a controller.
        /// </summary>
        /// <param name="descriptor">The <see cref="ControllerActionDescriptor"/>.</param>
        /// <returns>The delegate used to release the created controller.</returns>
        Action<ControllerContext, object> CreateControllerReleaser(ControllerActionDescriptor descriptor);
    }
}
