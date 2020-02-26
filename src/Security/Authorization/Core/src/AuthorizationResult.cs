// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Encapsulates the result of <see cref="IAuthorizationService.AuthorizeAsync(ClaimsPrincipal, object, IEnumerable{IAuthorizationRequirement})"/>.
    /// </summary>
    public class AuthorizationResult
    {
        private AuthorizationResult() { }

        /// <summary>
        /// True if authorization was successful.
        /// </summary>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// Contains information about why authorization failed.
        /// </summary>
        public AuthorizationFailure Failure { get; private set; }

        /// <summary>
        /// Returns a successful result.
        /// </summary>
        /// <returns>A successful result.</returns>
        public static AuthorizationResult Success() => new AuthorizationResult { Succeeded = true };

        public static AuthorizationResult Failed(AuthorizationFailure failure) => new AuthorizationResult { Failure = failure };

        public static AuthorizationResult Failed() => new AuthorizationResult { Failure = AuthorizationFailure.ExplicitFail() };

    }
}
