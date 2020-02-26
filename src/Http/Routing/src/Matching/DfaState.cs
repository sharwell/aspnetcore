// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;

namespace Microsoft.AspNetCore.Routing.Matching
{
    [DebuggerDisplay("{DebuggerToString(),nq}")]
    internal readonly struct DfaState
    {
        public readonly Candidate[] Candidates;
        public readonly IEndpointSelectorPolicy[] Policies;
        public readonly JumpTable PathTransitions;
        public readonly PolicyJumpTable PolicyTransitions;

        public DfaState(
            Candidate[] candidates,
            IEndpointSelectorPolicy[] policies,
            JumpTable pathTransitions,
            PolicyJumpTable policyTransitions)
        {
            Candidates = candidates;
            Policies = policies;
            PathTransitions = pathTransitions;
            PolicyTransitions = policyTransitions;
        }

        public string DebuggerToString()
        {
            return
                $"matches: {Candidates?.Length ?? 0}, " +
                $"path: ({PathTransitions?.DebuggerToString()}), " +
                $"policy: ({PolicyTransitions?.DebuggerToString()})";
        }
    }
}
