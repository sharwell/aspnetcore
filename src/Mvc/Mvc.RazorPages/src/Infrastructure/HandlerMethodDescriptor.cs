// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure
{
    public class HandlerMethodDescriptor
    {
        public MethodInfo MethodInfo { get; set; }

        public string HttpMethod { get; set; }

        public string Name { get; set; }

        public IList<HandlerParameterDescriptor> Parameters { get; set; }
    }
}
