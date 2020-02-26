// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views
{
    internal class DatabaseErrorPageModel
    {
        public DatabaseErrorPageModel(
            Type contextType,
            Exception exception,
            bool databaseExists,
            bool pendingModelChanges,
            IEnumerable<string> pendingMigrations,
            DatabaseErrorPageOptions options)
        {
            ContextType = contextType;
            Exception = exception;
            DatabaseExists = databaseExists;
            PendingModelChanges = pendingModelChanges;
            PendingMigrations = pendingMigrations;
            Options = options;
        }

        public virtual Type ContextType { get; }
        public virtual Exception Exception { get; }
        public virtual bool DatabaseExists { get; }
        public virtual bool PendingModelChanges { get; }
        public virtual IEnumerable<string> PendingMigrations { get; }
        public virtual DatabaseErrorPageOptions Options { get; }
    }
}