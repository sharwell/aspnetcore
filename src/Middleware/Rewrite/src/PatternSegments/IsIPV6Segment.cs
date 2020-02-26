﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net.Sockets;

namespace Microsoft.AspNetCore.Rewrite.PatternSegments
{
    internal class IsIPV6Segment : PatternSegment
    {
        public override string Evaluate(RewriteContext context, BackReferenceCollection ruleBackReferences, BackReferenceCollection conditionBackReferences)
        {
            if (context.HttpContext.Connection.RemoteIpAddress == null)
            {
                return "off";
            }
            return context.HttpContext.Connection.RemoteIpAddress.AddressFamily == AddressFamily.InterNetworkV6 ? "on" : "off";
        }
    }
}
