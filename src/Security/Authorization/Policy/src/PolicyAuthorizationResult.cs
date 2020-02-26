// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Authorization.Policy
{
    public class PolicyAuthorizationResult
    {
        private PolicyAuthorizationResult() { }

        /// <summary>
        /// If true, means the callee should challenge and try again.
        /// </summary>
        public bool Challenged { get; private set; }

        /// <summary>
        /// Authorization was forbidden.
        /// </summary>
        public bool Forbidden { get; private set; }

        /// <summary>
        /// Authorization was successful.
        /// </summary>
        public bool Succeeded { get; private set; }

        public static PolicyAuthorizationResult Challenge()
            => new PolicyAuthorizationResult { Challenged = true };

        public static PolicyAuthorizationResult Forbid()
            => new PolicyAuthorizationResult { Forbidden = true };

        public static PolicyAuthorizationResult Success()
            => new PolicyAuthorizationResult { Succeeded = true };

    }
}