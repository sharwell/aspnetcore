// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Rewrite.UrlMatches
{
    internal class ExactMatch : UrlMatch
    {
        private readonly bool _ignoreCase;
        private readonly string _stringMatch;

        public ExactMatch(bool ignoreCase, string input, bool negate)
        {
            _ignoreCase = ignoreCase;
            _stringMatch = input;
            Negate = negate;
        }

        public override MatchResults Evaluate(string pattern, RewriteContext context)
        {
            var pathMatch = string.Compare(pattern, _stringMatch, _ignoreCase);
            var success = ((pathMatch == 0) != Negate);
            if (success)
            {
                return new MatchResults { Success = success, BackReferences = new BackReferenceCollection(pattern) };
            }
            else
            {
                return MatchResults.EmptyFailure;
            }
        }
    }
}
