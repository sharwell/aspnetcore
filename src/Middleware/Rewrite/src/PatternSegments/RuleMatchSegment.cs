// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Rewrite.PatternSegments
{
    internal class RuleMatchSegment : PatternSegment
    {
        private readonly int _index;

        public RuleMatchSegment(int index)
        {
            _index = index;
        }

        public override string Evaluate(RewriteContext context, BackReferenceCollection ruleBackReferences, BackReferenceCollection conditionBackReferences)
        {
            return ruleBackReferences[_index];
        }
    }
}
