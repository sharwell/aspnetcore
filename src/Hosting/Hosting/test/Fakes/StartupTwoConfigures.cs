// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.Hosting.Fakes
{
    public class StartupTwoConfigures
    {
        public StartupTwoConfigures()
        {
        }

        public void Configure(IApplicationBuilder builder)
        {

        }

        public void Configure(IApplicationBuilder builder, object service)
        {

        }
    }
}