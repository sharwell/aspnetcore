// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Http.Connections
{
    public class NegotiationResponse
    {
        public string Url { get; set; }
        public string AccessToken { get; set; }
        public string ConnectionId { get; set; }
        public string ConnectionToken { get; set; }
        public int Version { get; set; }
        public IList<AvailableTransport> AvailableTransports { get; set; }
        public string Error { get; set; }
    }
}
