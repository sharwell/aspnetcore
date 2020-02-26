// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;

namespace Microsoft.AspNetCore.Analyzers
{
    internal class ServicesItem
    {
        public ServicesItem(IInvocationOperation operation)
        {
            Operation = operation;
        }

        public IInvocationOperation Operation { get; }

        public IMethodSymbol UseMethod => Operation.TargetMethod;
    }
}
