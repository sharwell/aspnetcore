// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace FunctionalTests
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class HubWithAuthorization : Hub
    {
        public string Echo(string message) => message;
    }
}
