// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Routing.Matching
{
    public readonly struct PolicyJumpTableEdge
    {
        public PolicyJumpTableEdge(object state, int destination)
        {
            State = state ?? throw new System.ArgumentNullException(nameof(state));
            Destination = destination;
        }

        public object State { get; }

        public int Destination { get; }
    }
}
