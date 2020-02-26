// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.Controllers
{
    /// <summary>
    /// Provides methods to create a controller.
    /// </summary>
    public interface IControllerActivator
    {
        /// <summary>
        /// Creates a controller.
        /// </summary>
        /// <param name="context">The <see cref="ControllerContext"/> for the executing action.</param>
        object Create(ControllerContext context);

        /// <summary>
        /// Releases a controller.
        /// </summary>
        /// <param name="context">The <see cref="ControllerContext"/> for the executing action.</param>
        /// <param name="controller">The controller to release.</param>
        void Release(ControllerContext context, object controller);
    }
}