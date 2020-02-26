// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Mvc.ModelBinding
{
    /// <summary>
    /// An interface that allows a top-level model to be bound or not bound based on state associated
    /// with the current request.
    /// </summary>
    public interface IRequestPredicateProvider
    {
        /// <summary>
        /// Gets a function which determines whether or not the model object should be bound based
        /// on the current request.
        /// </summary>
        Func<ActionContext, bool> RequestPredicate { get; }
    }
}
