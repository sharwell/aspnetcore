// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;

namespace ApplicationModelWebSite
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MultipleAreasAttribute : Attribute
    {
        public MultipleAreasAttribute(string area1, string area2, params string[] areaNames)
        {
            AreaNames = new string[] { area1, area2 }.Concat(areaNames).ToArray();
        }

        public string[] AreaNames { get; }
    }
}
