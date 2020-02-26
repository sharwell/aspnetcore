// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Tests.Helpers
{
    public class StringsHelpers
    {
        public static string GetResourceString(string stringName, params object[] parameters)
        {
            var strings = typeof(DatabaseErrorPageMiddleware).GetTypeInfo().Assembly.GetType("Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Strings").GetTypeInfo();
            var method = strings.GetDeclaredMethods(stringName).Single();
            return (string)method.Invoke(null, parameters);
        }
    }
}