// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.ConcurrencyLimiter
{
    /// <summary>
    /// Specifies options for the <see cref="IQueuePolicy"/>
    /// </summary>
    public class QueuePolicyOptions
    {
        /// <summary>
        /// Maximum number of concurrent requests. Any extras will be queued on the server. 
        /// This option is highly application dependant, and must be configured by the application.
        /// </summary>
        public int MaxConcurrentRequests { get; set; }

        /// <summary>
        /// Maximum number of queued requests before the server starts rejecting connections with '503 Service Unavailible'.
        /// This option is highly application dependant, and must be configured by the application.
        /// </summary>
        public int RequestQueueLimit { get; set; }
    }
}
