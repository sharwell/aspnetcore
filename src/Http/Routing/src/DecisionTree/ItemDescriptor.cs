// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Routing.DecisionTree
{
    internal class ItemDescriptor<TItem>
    {
        public IDictionary<string, DecisionCriterionValue> Criteria { get; set; }

        public int Index { get; set; }

        public TItem Item { get; set; }
    }
}