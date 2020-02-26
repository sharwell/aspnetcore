// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Server.IntegrationTesting.IIS
{
    public class RetryHandler : DelegatingHandler
    {
        private static readonly int MaxRetries = 5;
        private static readonly TimeSpan RetryDelay = TimeSpan.FromSeconds(1);

        private readonly ILogger _logger;

        public RetryHandler(HttpMessageHandler innerHandler, ILogger logger)
            : base(innerHandler)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            for (int i = 0; i < MaxRetries; i++)
            {
                response = null;
                try
                {
                    response = await base.SendAsync(request, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("Error sending request", ex);
                    if (i == MaxRetries - 1)
                    {
                        throw;
                    }
                }

                // Retry only on 503 that is expected during IIS startup
                if (response != null &&
                   (response.IsSuccessStatusCode || response.StatusCode != (HttpStatusCode)503))
                {
                    break;
                }

                _logger.LogDebug($"Retrying {i+1}th time after {RetryDelay.Seconds} sec.");
                await Task.Delay(RetryDelay, cancellationToken);
            }
            return response;
        }
    }
}
