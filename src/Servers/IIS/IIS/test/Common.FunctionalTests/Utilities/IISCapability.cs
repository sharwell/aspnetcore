// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Server.IIS.FunctionalTests
{
    [Flags]
    public enum IISCapability
    {
        None = 0,
        Websockets = 1,
        WindowsAuthentication = 2,
        PoolEnvironmentVariables = 4,
        DynamicCompression = 8,
        ApplicationInitialization = 16,
        TracingModule = 32,
        FailedRequestTracingModule = 64,
        BasicAuthentication = 128
    }
}
