// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace ControllersFromServicesWebSite.Components
{
    public class ComponentFromServicesViewComponent : ViewComponent
    {
        private readonly ValueService _value;

        public ComponentFromServicesViewComponent(ValueService value)
        {
            _value = value;
        }

        public string Invoke()
        {
            return $"Value = {_value.Value}";
        }
    }
}
