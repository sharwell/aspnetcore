// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Net.Http.Headers;

namespace Microsoft.AspNetCore.Http.Extensions
{
    public static class HttpRequestMultipartExtensions
    {
        public static string GetMultipartBoundary(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            MediaTypeHeaderValue mediaType;
            if (!MediaTypeHeaderValue.TryParse(request.ContentType, out mediaType))
            {
                return string.Empty;
            }
            return HeaderUtilities.RemoveQuotes(mediaType.Boundary).ToString();
        }
    }
}
