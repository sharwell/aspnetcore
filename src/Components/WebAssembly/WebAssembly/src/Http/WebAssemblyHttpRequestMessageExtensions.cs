// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.AspNetCore.Components.WebAssembly.Http
{
    /// <summary>
    /// Extension methods for configuring an instance <see cref="HttpRequestMessage"/> with Fetch specific options.
    /// </summary>
    public static class WebAssemblyHttpRequestMessageExtensions
    {
        /// <summary>
        /// Configures a value for the 'credentials' option for the HTTP request.
        /// </summary>
        /// <param name="requestMessage">The <see cref="HttpRequestMessage"/>.</param>
        /// <param name="requestCredentials">The <see cref="RequestCredentials"/>.</param>
        /// <returns>The <see cref="HttpRequestMessage"/>.</returns>
        /// <remarks>
        /// See https://developer.mozilla.org/en-US/docs/Web/API/Request/credentials
        /// </remarks>
        public static HttpRequestMessage WithRequestCredentials(this HttpRequestMessage requestMessage, RequestCredentials requestCredentials)
        {
            if (requestMessage is null)
            {
                throw new ArgumentNullException(nameof(requestMessage));
            }

            var stringOption = requestCredentials switch
            {
                RequestCredentials.Omit => "omit",
                RequestCredentials.SameOrigin => "same-origin",
                RequestCredentials.Include => "include",
                _ => throw new InvalidOperationException($"Unsupported enum value {requestCredentials}.")
            };

            return WithFetchOption(requestMessage, "credentials", stringOption);
        }

        /// <summary>
        /// Configures a value for the 'cache' option for the HTTP request.
        /// </summary>
        /// <param name="requestMessage">The <see cref="HttpRequestMessage"/>.</param>
        /// <param name="requestCache">The <see cref="RequestCache"/>.</param>
        /// <returns>The <see cref="HttpRequestMessage"/>.</returns>\
        /// <remarks>
        /// See https://developer.mozilla.org/en-US/docs/Web/API/Request/cache
        /// </remarks>
        public static HttpRequestMessage WithRequestCache(this HttpRequestMessage requestMessage, RequestCache requestCache)
        {
            if (requestMessage is null)
            {
                throw new ArgumentNullException(nameof(requestMessage));
            }

            var stringOption = requestCache switch
            {
                RequestCache.Default => "default",
                RequestCache.NoStore => "no-store",
                RequestCache.Reload => "reload",
                RequestCache.NoCache => "no-cache",
                RequestCache.ForceCache => "force-cache",
                RequestCache.OnlyIfCached => "only-if-cached",
                _ => throw new InvalidOperationException($"Unsupported enum value {requestCache}.")
            };

            return WithFetchOption(requestMessage, "cache", stringOption);
        }

        /// <summary>
        /// Configures a value for the 'mode' option for the HTTP request.
        /// </summary>
        /// <param name="requestMessage">The <see cref="HttpRequestMessage"/>.</param>
        /// <param name="requestMode">The <see cref="RequestMode"/>.</param>
        /// <returns>The <see cref="HttpRequestMessage"/>.</returns>\
        /// <remarks>
        /// See https://developer.mozilla.org/en-US/docs/Web/API/Request/mode
        /// </remarks>
        public static HttpRequestMessage WithRequestMode(this HttpRequestMessage requestMessage, RequestMode requestMode)
        {
            if (requestMessage is null)
            {
                throw new ArgumentNullException(nameof(requestMessage));
            }

            var stringOption = requestMode switch
            {
                RequestMode.SameOrigin => "same-origin",
                RequestMode.NoCors => "no-cors",
                RequestMode.Cors => "cors",
                RequestMode.Navigate => "navigate",
                _ => throw new InvalidOperationException($"Unsupported enum value {requestMode}.")
            };

            return WithFetchOption(requestMessage, "mode", stringOption);
        }

        /// <summary>
        /// Configures a value for the 'integrity' option for the HTTP request.
        /// </summary>
        /// <param name="requestMessage">The <see cref="HttpRequestMessage"/>.</param>
        /// <param name="integrity">The subresource integrity.</param>
        /// <returns>The <see cref="HttpRequestMessage"/>.</returns>
        public static HttpRequestMessage WithIntegrity(this HttpRequestMessage requestMessage, string integrity)
            => WithFetchOption(requestMessage, "integrity", integrity);

        /// <summary>
        /// Configures a value for the fetch request.
        /// </summary>
        /// <param name="requestMessage">The <see cref="HttpRequestMessage"/>.</param>
        /// <param name="key">The key for the HTTP fetch optin.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="HttpRequestMessage"/>.</returns>
        /// <remarks>
        /// See https://developer.mozilla.org/en-US/docs/Web/API/WindowOrWorkerGlobalScope/fetch
        /// </remarks>
        public static HttpRequestMessage WithFetchOption(this HttpRequestMessage requestMessage, string key, object value)
        {
            if (requestMessage is null)
            {
                throw new ArgumentNullException(nameof(requestMessage));
            }

            SetFetchOption(requestMessage, key, value);
            return requestMessage;
        }


        private static void SetFetchOption(HttpRequestMessage requestMessage, string key, object value)
        {
            const string FetchRequestOptionsKey = "FetchRequestOptions";
            IDictionary<string, object> fetchOptions;

            if (requestMessage.Properties.TryGetValue(FetchRequestOptionsKey, out var entry))
            {
                fetchOptions = (IDictionary<string, object>)entry;
            }
            else
            {
                fetchOptions = new Dictionary<string, object>();
                requestMessage.Properties[FetchRequestOptionsKey] = fetchOptions;
            }

            fetchOptions[key] = value;
        }
    }
}
