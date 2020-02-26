// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BasicWebSite
{
    [BindProperties(SupportsGet = true)]
    public class BindPropertiesSupportsGetController : Controller
    {
        public string Name { get; set; }

        public IActionResult Action() => Content(Name);
    }
}
