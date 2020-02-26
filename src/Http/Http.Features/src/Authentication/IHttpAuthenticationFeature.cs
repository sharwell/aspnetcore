// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Http.Features.Authentication
{
    public interface IHttpAuthenticationFeature
    {
        ClaimsPrincipal User { get; set; }
    }
}
