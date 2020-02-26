// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Microsoft.AspNetCore.SignalR.Tests
{
    public class TestAuthHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            foreach (var req in context.Requirements)
            {
                context.Succeed(req);
            }

            var hasClaim = context.User.HasClaim(o => o.Type == ClaimTypes.NameIdentifier && !string.IsNullOrEmpty(o.Value));

            if (!hasClaim)
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
