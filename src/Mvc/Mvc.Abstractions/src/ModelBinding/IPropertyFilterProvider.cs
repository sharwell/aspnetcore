// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.ModelBinding
{
    /// <summary>
    /// Provides a predicate which can determines which model properties should be bound by model binding.
    /// </summary>
    public interface IPropertyFilterProvider
    {
        /// <summary>
        /// Gets a predicate which can determines which model properties should be bound by model binding.
        /// </summary>
        Func<ModelMetadata, bool> PropertyFilter { get; }
    }
}
