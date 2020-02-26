// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Routing.DecisionTree
{
    internal interface IClassifier<TItem>
    {
        IDictionary<string, DecisionCriterionValue> GetCriteria(TItem item);

        IEqualityComparer<object> ValueComparer { get; }
    }
}