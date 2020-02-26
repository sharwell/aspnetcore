// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using BasicWebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebSite.Controllers.ActionConstraints
{
    [Consumes("application/xml")]
    public class ConsumesAttribute_OverridesController : ConsumesAttribute_OverridesBaseController
    {
        public override IActionResult CreateProduct([FromBody] Product product)
        {
            // should be picked if request content type is text/json.
            product.SampleString = "ConsumesAttribute_OverridesController_application/xml";
            return new JsonResult(product);
        }
    }
}