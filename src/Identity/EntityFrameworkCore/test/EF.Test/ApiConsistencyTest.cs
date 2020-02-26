// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Reflection;
using Microsoft.AspNetCore.Identity.Test;

namespace Microsoft.AspNetCore.Identity.EntityFrameworkCore.Test
{
    public class ApiConsistencyTest : ApiConsistencyTestBase
    {
        protected override Assembly TargetAssembly => typeof(IdentityUser).GetTypeInfo().Assembly;
    }
}
