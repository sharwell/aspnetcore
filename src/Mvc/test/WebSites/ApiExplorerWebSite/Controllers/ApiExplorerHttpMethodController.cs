// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace ApiExplorerWebSite
{
    [Route("ApiExplorerHttpMethod")]
    public class ApiExplorerHttpMethodController : Controller
    {
        [Route("All")]
        public void All()
        {
        }

        [HttpGet("Get")]
        public void Get()
        {
        }

        [AcceptVerbs("PUT", "POST", Route = "Single")]
        public void PutOrPost()
        {
        }

        [HttpGet("MultipleActions")]
        [HttpPut("MultipleActions")]
        public void MultipleActions()
        {
        }
    }
}