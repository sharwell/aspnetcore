// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Testing;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class RequiresNewHandlerAttribute : Attribute, ITestCondition
    {
        public bool IsMet => DeployerSelector.HasNewHandler;

        public string SkipReason => "Test verifies new behavior in the aspnetcorev2_inprocess.dll that isn't supported in earlier versions.";
    }
}
