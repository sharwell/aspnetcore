// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Microsoft.AspNetCore.Mvc.ModelBinding
{
    internal class ReferenceEqualityComparer : IEqualityComparer<object>
    {
        private static readonly bool IsMono = Type.GetType("Mono.Runtime") != null;

        public static ReferenceEqualityComparer Instance { get; } = new ReferenceEqualityComparer();

        public new bool Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }

        public int GetHashCode(object obj)
        {
            // RuntimeHelpers.GetHashCode sometimes crashes the runtime on Mono 4.0.4
            // See: https://github.com/aspnet/External/issues/45
            // The workaround here is to just not hash anything, and fall back to an equality check.
            if (IsMono)
            {
                return 0;
            }

            return RuntimeHelpers.GetHashCode(obj);
        }
    }
}
