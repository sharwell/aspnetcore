// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;

namespace Microsoft.AspNetCore.DataProtection.Repositories
{
    /// <summary>
    /// This interface enables overridding the default storage location of keys on disk
    /// </summary>
    internal interface IDefaultKeyStorageDirectories
    {
        DirectoryInfo GetKeyStorageDirectory();

        DirectoryInfo GetKeyStorageDirectoryForAzureWebSites();
    }
}
