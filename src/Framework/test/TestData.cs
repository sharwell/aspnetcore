// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.AspNetCore
{
    public class TestData
    {
        public static string GetSharedFxVersion() => GetTestDataValue("SharedFxVersion");

        public static string GetMicrosoftNETCoreAppPackageVersion() => GetTestDataValue("MicrosoftNETCoreAppRuntimeVersion");

        public static string GetRepositoryCommit() => GetTestDataValue("RepositoryCommit");

        public static string GetSharedFxRuntimeIdentifier() => GetTestDataValue("TargetRuntimeIdentifier");

        public static string GetSharedFxDependencies() => GetTestDataValue("SharedFxDependencies");

        public static string GetTargetingPackDependencies() => GetTestDataValue("TargetingPackDependencies");

        public static bool VerifyAncmBinary() => string.Equals(GetTestDataValue("VerifyAncmBinary"), "true", StringComparison.OrdinalIgnoreCase);

        public static string GetTestDataValue(string key)
             => typeof(TestData).Assembly.GetCustomAttributes<TestDataAttribute>().Single(d => d.Key == key).Value;
    }
}
