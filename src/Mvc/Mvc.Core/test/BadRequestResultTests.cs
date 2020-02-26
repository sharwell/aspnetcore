// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Xunit;

namespace Microsoft.AspNetCore.Mvc
{
    public class BadRequestResultTests
    {
        [Fact]
        public void BadRequestResult_InitializesStatusCode()
        {
            // Arrange & act
            var badRequest = new BadRequestResult();

            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, badRequest.StatusCode);
        }
    }
}