// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Encapsulates a failure result of <see cref="IAuthorizationService.AuthorizeAsync(ClaimsPrincipal, object, IEnumerable{IAuthorizationRequirement})"/>.
    /// </summary>
    public class AuthorizationFailure
    {
        private AuthorizationFailure() { }

        /// <summary>
        /// Failure was due to <see cref="AuthorizationHandlerContext.Fail"/> being called.
        /// </summary>
        public bool FailCalled { get; private set; }

        /// <summary>
        /// Failure was due to these requirements not being met via <see cref="AuthorizationHandlerContext.Succeed(IAuthorizationRequirement)"/>.
        /// </summary>
        public IEnumerable<IAuthorizationRequirement> FailedRequirements { get; private set; }

        /// <summary>
        /// Return a failure due to <see cref="AuthorizationHandlerContext.Fail"/> being called.
        /// </summary>
        /// <returns>The failure.</returns>
        public static AuthorizationFailure ExplicitFail()
            => new AuthorizationFailure
            {
                FailCalled = true,
                FailedRequirements = new IAuthorizationRequirement[0]
            };

        /// <summary>
        /// Return a failure due to some requirements not being met via <see cref="AuthorizationHandlerContext.Succeed(IAuthorizationRequirement)"/>.
        /// </summary>
        /// <param name="failed">The requirements that were not met.</param>
        /// <returns>The failure.</returns>
        public static AuthorizationFailure Failed(IEnumerable<IAuthorizationRequirement> failed)
            => new AuthorizationFailure { FailedRequirements = failed };

    }
}
