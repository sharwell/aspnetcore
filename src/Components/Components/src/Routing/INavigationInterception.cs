// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components.Routing
{
    /// <summary>
    /// Contract to setup navigation interception on the client.
    /// </summary>
    public interface INavigationInterception
    {
        /// <summary>
        /// Enables navigation interception on the client.
        /// </summary>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
        Task EnableNavigationInterceptionAsync();
    }
}
