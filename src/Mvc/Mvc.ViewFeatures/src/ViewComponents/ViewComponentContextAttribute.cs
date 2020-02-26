// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.ViewComponents
{
    /// <summary>
    /// Specifies that a controller property should be set with the current
    /// <see cref="ViewComponentContext"/> when creating the view component. The property must have a public
    /// set method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ViewComponentContextAttribute : Attribute
    {
    }
}
