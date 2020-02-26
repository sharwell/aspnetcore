// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc
{
    /// <summary>
    /// A <see cref="StatusCodeResult"/> that when
    /// executed will produce a UnsupportedMediaType (415) response.
    /// </summary>
    [DefaultStatusCode(DefaultStatusCode)]
    public class UnsupportedMediaTypeResult : StatusCodeResult
    {
        private const int DefaultStatusCode = StatusCodes.Status415UnsupportedMediaType;

        /// <summary>
        /// Creates a new instance of <see cref="UnsupportedMediaTypeResult"/>.
        /// </summary>
        public UnsupportedMediaTypeResult() : base(DefaultStatusCode)
        {
        }
    }
}
