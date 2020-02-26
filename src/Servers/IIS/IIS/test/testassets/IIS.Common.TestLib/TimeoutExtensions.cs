// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Testing;

namespace Microsoft.AspNetCore.Server.IntegrationTesting
{

    public static class TimeoutExtensions
    {
        public static TimeSpan DefaultTimeoutValue = TimeSpan.FromSeconds(300);

        public static Task DefaultTimeout(this Task task, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1)
        {
            return task.TimeoutAfter(DefaultTimeoutValue, filePath, lineNumber);
        }

        public static Task<T> DefaultTimeout<T>(this Task<T> task, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = -1)
        {
            return task.TimeoutAfter(DefaultTimeoutValue, filePath, lineNumber);
        }
    }
}
