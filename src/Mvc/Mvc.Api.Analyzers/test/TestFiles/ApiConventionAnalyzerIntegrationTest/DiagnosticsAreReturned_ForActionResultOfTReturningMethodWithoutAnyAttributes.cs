﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace Microsoft.AspNetCore.Mvc.Api.Analyzers
{
    [ApiController]
    public class DiagnosticsAreReturned_ForActionResultOfTReturningMethodWithoutAnyAttributes : ControllerBase
    {
        public ActionResult<string> Method(Guid? id)
        {
            if (id == null)
            {
                /*MM*/return NotFound();
            }

            return "Hello world";
        }
    }
}
