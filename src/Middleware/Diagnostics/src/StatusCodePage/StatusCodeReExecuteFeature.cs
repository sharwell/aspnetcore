// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Diagnostics
{
    public class StatusCodeReExecuteFeature : IStatusCodeReExecuteFeature
    {
        public string OriginalPath { get; set; }

        public string OriginalPathBase { get; set; }

        public string OriginalQueryString { get; set; }
    }
}