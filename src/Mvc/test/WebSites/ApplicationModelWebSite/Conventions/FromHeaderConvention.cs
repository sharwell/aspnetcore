// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ApplicationModelWebSite
{
    public class FromHeaderConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            foreach (var param in action.Parameters)
            {
                if (param.Attributes.Any(p => p.GetType() == typeof(FromHeaderAttribute)))
                {
                    param.Action.Properties["source"] = "From Header";
                }
            }
        }
    }
}