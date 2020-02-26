﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using FormatterWebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormatterWebSite.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestApiController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostBookWithNoValidation(BookModelWithNoValidation bookModel) => Ok();
    }
}
