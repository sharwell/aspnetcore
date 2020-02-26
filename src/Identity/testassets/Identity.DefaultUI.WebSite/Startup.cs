// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Identity.DefaultUI.WebSite
{
    public class Startup : StartupBase<IdentityUser, IdentityDbContext>
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
