// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

[assembly: ApiController]

namespace Microsoft.AspNetCore.Mvc.Api.Analyzers.TestFiles.ApiControllerFactsTest
{
    public class IsApiControllerAction_ReturnsTrue_IfAttributeIsDeclaredOnAssemblyController : ControllerBase
    {
        public IActionResult Action() => null;
    }
}
