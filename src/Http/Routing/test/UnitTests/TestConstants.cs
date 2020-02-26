﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Routing
{
    public static class TestConstants
    {
        internal static readonly RequestDelegate EmptyRequestDelegate = (context) => Task.CompletedTask;
    }
}
