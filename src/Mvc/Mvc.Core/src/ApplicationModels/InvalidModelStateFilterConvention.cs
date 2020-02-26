// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc.ApplicationModels
{
    /// <summary>
    /// An <see cref="IActionModelConvention"/> that adds a <see cref="IFilterMetadata"/>
    /// to <see cref="ActionModel"/> that responds to invalid <see cref="ActionContext.ModelState"/>
    /// </summary>
    public class InvalidModelStateFilterConvention : IActionModelConvention
    {
        private readonly ModelStateInvalidFilterFactory _filterFactory = new ModelStateInvalidFilterFactory();

        public void Apply(ActionModel action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (!ShouldApply(action))
            {
                return;
            }

            action.Filters.Add(_filterFactory);
        }

        protected virtual bool ShouldApply(ActionModel action) => true;
    }
}
