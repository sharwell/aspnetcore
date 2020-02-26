// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authentication
{
    /// <summary>
    /// Used to determine if a handler wants to participate in request processing.
    /// </summary>
    public interface IAuthenticationRequestHandler : IAuthenticationHandler
    {
        /// <summary>
        /// Returns true if request processing should stop.
        /// </summary>
        /// <returns><see langword="true" /> if request processing should stop.</returns>
        Task<bool> HandleRequestAsync();
    }

}
