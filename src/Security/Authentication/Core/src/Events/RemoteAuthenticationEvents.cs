// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authentication
{
    public class RemoteAuthenticationEvents
    {
        public Func<AccessDeniedContext, Task> OnAccessDenied { get; set; } = context => Task.CompletedTask;
        public Func<RemoteFailureContext, Task> OnRemoteFailure { get; set; } = context => Task.CompletedTask;

        public Func<TicketReceivedContext, Task> OnTicketReceived { get; set; } = context => Task.CompletedTask;

        /// <summary>
        /// Invoked when an access denied error was returned by the remote server.
        /// </summary>
        public virtual Task AccessDenied(AccessDeniedContext context) => OnAccessDenied(context);

        /// <summary>
        /// Invoked when there is a remote failure.
        /// </summary>
        public virtual Task RemoteFailure(RemoteFailureContext context) => OnRemoteFailure(context);

        /// <summary>
        /// Invoked after the remote ticket has been received.
        /// </summary>
        public virtual Task TicketReceived(TicketReceivedContext context) => OnTicketReceived(context);
    }
}