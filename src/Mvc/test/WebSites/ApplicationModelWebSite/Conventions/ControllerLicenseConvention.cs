// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ApplicationModelWebSite
{
    public class ControllerLicenseConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.Properties["license"] = "Copyright (c) .NET Foundation. All rights reserved." +
                " Licensed under the Apache License, Version 2.0. See License.txt " +
                "in the project root for license information.";
        }
    }
}