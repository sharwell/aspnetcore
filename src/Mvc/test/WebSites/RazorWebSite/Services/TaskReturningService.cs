// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;

namespace RazorWebSite
{
    public class TaskReturningService
    {
        public async Task<string> GetValueAsync()
        {
            await Task.Delay(100);
            return "Value from TaskReturningString";
        }
    }
}