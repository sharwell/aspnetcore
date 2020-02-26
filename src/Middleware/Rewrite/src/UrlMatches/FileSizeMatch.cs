﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Rewrite.UrlMatches
{
    internal class FileSizeMatch : UrlMatch
    {
        public FileSizeMatch(bool negate)
        {
            Negate = negate;
        }

        public override MatchResults Evaluate(string input, RewriteContext context)
        {
            var fileInfo = context.StaticFileProvider.GetFileInfo(input);
            return fileInfo.Exists && fileInfo.Length > 0 ? MatchResults.EmptySuccess : MatchResults.EmptyFailure;
        }
    }
}
