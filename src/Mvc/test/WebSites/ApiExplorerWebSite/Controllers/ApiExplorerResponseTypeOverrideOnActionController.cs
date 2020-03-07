// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace ApiExplorerWebSite
{
    [Produces("application/json", Type = typeof(Product))]
    [ProducesResponseType(typeof(ErrorInfo), 500)]
    [Route("ApiExplorerResponseTypeOverrideOnAction")]
    public class ApiExplorerResponseTypeOverrideOnActionController : Controller
    {
        [HttpGet("Controller")]
        public void GetController()
        {
        }

        [HttpGet("Action")]
        [Produces(typeof(Customer))]
        [ProducesResponseType(typeof(ErrorInfoOverride), 500)] // overriding the type specified on the server
        public object GetAction()
        {
            return null;
        }
    }

    public class ErrorInfo
    {
        public string Message { get; set; }
    }

    public class ErrorInfoOverride { }
}