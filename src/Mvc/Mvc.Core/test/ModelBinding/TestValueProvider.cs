// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.Mvc.ModelBinding
{
    public class TestValueProvider : RouteValueProvider
    {
        public static readonly BindingSource TestBindingSource = new BindingSource(
            id: "Test",
            displayName: "Test",
            isGreedy: false,
            isFromRequest: true);

        public TestValueProvider(IDictionary<string, object> values)
            : base(TestBindingSource, new RouteValueDictionary(values))
        {
        }

        public TestValueProvider(BindingSource bindingSource, IDictionary<string, object> values)
            : base(bindingSource, new RouteValueDictionary(values))
        {
        }
    }
}