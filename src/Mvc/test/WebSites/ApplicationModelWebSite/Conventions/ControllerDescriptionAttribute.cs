// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ApplicationModelWebSite
{
    public class ControllerDescriptionAttribute : Attribute, IControllerModelConvention
    {
        private object _value;

        public ControllerDescriptionAttribute(object value)
        {
            _value = value;
        }

        public void Apply(ControllerModel model)
        {
            model.Properties["description"] = _value;
        }
    }
}