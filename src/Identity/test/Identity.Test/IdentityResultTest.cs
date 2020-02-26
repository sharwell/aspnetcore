// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using Xunit;

namespace Microsoft.AspNetCore.Identity.Test
{
    public class IdentityResultTest
    {
        [Fact]
        public void VerifyDefaultConstructor()
        {
            var result = new IdentityResult();
            Assert.False(result.Succeeded);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void NullFailedUsesEmptyErrors()
        {
            var result = IdentityResult.Failed();
            Assert.False(result.Succeeded);
            Assert.Empty(result.Errors);
        }
    }
}
