﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.Razor.Compilation
{
    [Obsolete("This attribute has been superseded by RazorCompiledItem and will not be used by the runtime.")]
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class RazorViewAttribute : Attribute
    {
        public RazorViewAttribute(string path, Type viewType)
        {
            Path = path;
            ViewType = viewType;
        }

        /// <summary>
        /// Gets the path of the view.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the view type.
        /// </summary>
        public Type ViewType { get; }
    }
}
