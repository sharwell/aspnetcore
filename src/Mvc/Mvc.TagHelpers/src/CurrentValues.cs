// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.AspNetCore.Mvc.TagHelpers
{
    internal class CurrentValues
    {
        public CurrentValues(ICollection<string> values)
        {
            Debug.Assert(values != null);
            Values = values;
        }

        public ICollection<string> Values { get; }

        public ICollection<string> ValuesAndEncodedValues { get; set; }
    }
}
