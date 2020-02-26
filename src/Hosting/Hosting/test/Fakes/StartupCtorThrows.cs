// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.Hosting.Fakes
{
    public class StartupCtorThrows
    {
        public StartupCtorThrows()
        {
            throw new Exception("Exception from constructor");
        }

        public void Configure(IApplicationBuilder app)
        {
        }
    }
}