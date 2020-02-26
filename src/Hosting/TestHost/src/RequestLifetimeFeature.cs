// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;
using Microsoft.AspNetCore.Http.Features;

namespace Microsoft.AspNetCore.TestHost
{
    internal class RequestLifetimeFeature : IHttpRequestLifetimeFeature
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly Action<Exception> _abort;

        public RequestLifetimeFeature(Action<Exception> abort)
        {
            RequestAborted = _cancellationTokenSource.Token;
            _abort = abort;
        }

        public CancellationToken RequestAborted { get; set; }

        internal void Cancel()
        {
            _cancellationTokenSource.Cancel();
        }

        void IHttpRequestLifetimeFeature.Abort()
        {
            _abort(new Exception("The application aborted the request."));
            _cancellationTokenSource.Cancel();
        }
    }
}
