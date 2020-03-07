﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;

[assembly: Microsoft.AspNetCore.Mvc.ApiConventionType(typeof(Microsoft.AspNetCore.Mvc.DefaultApiConventions))]

namespace TestApp._OUTPUT_
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseController : ControllerBase
    {

    }
}

namespace TestApp._OUTPUT_
{
    public class CodeFixAddsFullyQualifiedProducesResponseType : BaseController
    {
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status202Accepted)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status404NotFound)]
        [Microsoft.AspNetCore.Mvc.ProducesDefaultResponseType]
        public object GetItem(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if (id == 1)
            {
                return BadRequest();
            }

            return Accepted(new object());
        }
    }
}
