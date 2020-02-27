// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Identity
{
    public partial class SignInManager<TUser> where TUser : class
    {
        [System.Diagnostics.DebuggerStepThroughAttribute]
        internal System.Threading.Tasks.Task<System.Security.Claims.ClaimsPrincipal> StoreRememberClient(TUser user) { throw null; }
        internal System.Security.Claims.ClaimsPrincipal StoreTwoFactorInfo(string userId, string loginProvider) { throw null; }
        internal partial class TwoFactorAuthenticationInfo
        {
            public TwoFactorAuthenticationInfo() { }
            public string LoginProvider { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
            public string UserId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
        }
    }
}
