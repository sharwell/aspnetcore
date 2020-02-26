// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Testing;
using System;

namespace Microsoft.AspNetCore.DataProtection
{
    internal class TestRedisServerIsAvailableAttribute : Attribute, ITestCondition
    {
        public bool IsMet => !string.IsNullOrEmpty(TestRedisServer.GetConnectionString());

        public string SkipReason => $"A test redis server must be configured to run. Set the connection string as an environment variable as {TestRedisServer.ConnectionStringKeyName.Replace(":", "__")} or in testconfig.json";
    }
}