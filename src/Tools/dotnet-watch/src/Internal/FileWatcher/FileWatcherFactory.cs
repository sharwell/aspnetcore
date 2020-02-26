﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.DotNet.Watcher.Internal
{
    public static class FileWatcherFactory
    {
        public static IFileSystemWatcher CreateWatcher(string watchedDirectory)
            => CreateWatcher(watchedDirectory, CommandLineOptions.IsPollingEnabled);

        public static IFileSystemWatcher CreateWatcher(string watchedDirectory, bool usePollingWatcher)
        {
            return usePollingWatcher ?
                new PollingFileWatcher(watchedDirectory) :
                new DotnetFileWatcher(watchedDirectory) as IFileSystemWatcher;
        }
    }
}
