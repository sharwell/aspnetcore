// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Rewrite.UrlMatches
{
    internal class IsFileMatch : UrlMatch
    {
        public IsFileMatch(bool negate)
        {
            Negate = negate;
        }

        public override MatchResults Evaluate(string pattern, RewriteContext context)
        {
            var res = context.StaticFileProvider.GetFileInfo(pattern).Exists;
            return new MatchResults { Success = (res != Negate) };
        }
    }
}
