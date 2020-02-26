﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.Api.Analyzers.TestFiles.ApiActionsDoNotRequireExplicitModelValidationCheckCodeFixProviderTest._OUTPUT_
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CodeFixRemovesModelStateIsInvalidBlockWithEqualityCheck : ControllerBase
    {
        public IActionResult Method(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
