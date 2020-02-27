// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Authorization
{
    public partial interface IAllowAnonymous
    {
    }
    public partial interface IAuthorizeData
    {
        string AuthenticationSchemes { get; set; }
        string Policy { get; set; }
        string Roles { get; set; }
    }
}
