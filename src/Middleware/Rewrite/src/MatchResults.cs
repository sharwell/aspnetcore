// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.RegularExpressions;

namespace Microsoft.AspNetCore.Rewrite
{
    internal class MatchResults
    {
        public static readonly MatchResults EmptySuccess = new MatchResults { Success = true };
        public static readonly MatchResults EmptyFailure = new MatchResults { Success = false };

        public bool Success { get; set; }
        public BackReferenceCollection BackReferences { get; set; }
    }
}
