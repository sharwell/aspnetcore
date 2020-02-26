// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Builder;
using Xunit;

namespace Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Tests
{
    public class DatabaseErrorPageOptionsTest
    {
        [Fact]
        public void Empty_MigrationsEndPointPath_by_default()
        {
            var options = new DatabaseErrorPageOptions();

            Assert.Equal(MigrationsEndPointOptions.DefaultPath, options.MigrationsEndPointPath);
        }

        [Fact]
        public void MigrationsEndPointPath_is_respected()
        {
            var options = new DatabaseErrorPageOptions();
            options.MigrationsEndPointPath = "/test";
            
            Assert.Equal("/test", options.MigrationsEndPointPath);
        }
    }
}