// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Rewrite.ApacheModRewrite
{
    internal class Condition
    {
        public Pattern Input { get; set; }
        public UrlMatch Match { get; set; }
        public bool OrNext { get; set; }

        public MatchResults Evaluate(RewriteContext context, BackReferenceCollection ruleBackReferences, BackReferenceCollection conditionBackReferences)
        {
            var pattern = Input.Evaluate(context, ruleBackReferences, conditionBackReferences);
            return Match.Evaluate(pattern, context);
        }
    }
}