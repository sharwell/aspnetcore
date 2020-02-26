// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Routing.Matching
{
    public abstract class PolicyJumpTable
    {
        public abstract int GetDestination(HttpContext httpContext);

        internal virtual string DebuggerToString()
        {
            return GetType().Name;
        }
    }
}
