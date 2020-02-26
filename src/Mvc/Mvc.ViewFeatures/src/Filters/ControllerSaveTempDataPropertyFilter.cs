﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc.Filters;

namespace Microsoft.AspNetCore.Mvc.ViewFeatures.Filters
{
    internal class ControllerSaveTempDataPropertyFilter : SaveTempDataPropertyFilterBase, IActionFilter
    {
        public ControllerSaveTempDataPropertyFilter(ITempDataDictionaryFactory factory)
            : base(factory)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <inheritdoc />
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Subject = context.Controller;
            var tempData = _tempDataFactory.GetTempData(context.HttpContext);

            SetPropertyValues(tempData);
        }
    }
}
