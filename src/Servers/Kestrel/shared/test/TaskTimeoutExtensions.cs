// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Testing;

namespace System.Threading.Tasks
{
    public static class TaskTimeoutExtensions
    {
        public static Task<T> DefaultTimeout<T>(this ValueTask<T> task)
        {
            return task.AsTask().TimeoutAfter(TestConstants.DefaultTimeout);
        }

        public static Task DefaultTimeout(this ValueTask task)
        {
            return task.AsTask().TimeoutAfter(TestConstants.DefaultTimeout);
        }

        public static Task<T> DefaultTimeout<T>(this Task<T> task)
        {
            return task.TimeoutAfter(TestConstants.DefaultTimeout);
        }

        public static Task DefaultTimeout(this Task task)
        {
            return task.TimeoutAfter(TestConstants.DefaultTimeout);
        }
    }
}
