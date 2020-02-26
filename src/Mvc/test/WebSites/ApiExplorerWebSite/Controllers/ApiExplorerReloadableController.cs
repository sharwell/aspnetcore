// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace ApiExplorerWebSite
{
    [Route("ApiExplorerReload")]
    public class ApiExplorerReloadableController : Controller
    {
        [Route("Index")]
        [Reload]
        public string Index() => "Hello world";

        [Route("Reload")]
        [PassThru]
        public IActionResult Reload([FromServices] WellKnownChangeToken changeToken)
        {
            changeToken.TokenSource.Cancel();
            return Ok();
        }
    }
}
