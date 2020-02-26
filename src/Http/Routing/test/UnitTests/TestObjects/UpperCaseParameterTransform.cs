// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Routing.TestObjects
{
    public class UpperCaseParameterTransform : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            return value?.ToString()?.ToUpperInvariant();
        }
    }
}
