// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Blazor.Server.AutoRebuild
{
    /// <summary>
    /// Represents a mechanism for rebuilding a .NET project. For example, it
    /// could be a way of signalling to a VS process to perform a build.
    /// </summary>
    internal interface IRebuildService
    {
        Task<bool> PerformRebuildAsync(string projectFullPath, DateTime ifNotBuiltSince);
    }
}
