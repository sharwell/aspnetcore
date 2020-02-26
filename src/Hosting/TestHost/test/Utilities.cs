// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Testing;

namespace Microsoft.AspNetCore.TestHost
{
    internal static class Utilities
    {
        internal static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(15);

        internal static Task<T> WithTimeout<T>(this Task<T> task) => task.TimeoutAfter(DefaultTimeout);

        internal static Task WithTimeout(this Task task) => task.TimeoutAfter(DefaultTimeout);
    }
}
