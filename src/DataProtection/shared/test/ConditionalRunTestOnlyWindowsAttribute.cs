// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Cryptography.Cng;
using Microsoft.AspNetCore.Testing;

namespace Microsoft.AspNetCore.DataProtection.Test.Shared
{
    public class ConditionalRunTestOnlyOnWindowsAttribute : Attribute, ITestCondition
    {
        public bool IsMet => OSVersionUtil.IsWindows();

        public string SkipReason { get; } = "Test requires Windows 7 / Windows Server 2008 R2 or higher.";
    }
}
