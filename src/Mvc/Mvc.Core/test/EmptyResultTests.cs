// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;

namespace Microsoft.AspNetCore.Mvc
{
    public class EmptyResultTests
    {
        [Fact]
        public void EmptyResult_ExecuteResult_IsANoOp()
        {
            // Arrange
            var emptyResult = new EmptyResult();

            var httpContext = new Mock<HttpContext>(MockBehavior.Strict);
            var routeData = new RouteData();
            var actionDescriptor = new ActionDescriptor();

            var context = new ActionContext(httpContext.Object, routeData, actionDescriptor);

            // Act & Assert (does not throw)
            emptyResult.ExecuteResult(context);
        }
    }
}