// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    /// <summary>
    /// Represents an <see cref="IActionResult"/> that when executed will
    /// produce an HTTP response with the specified <see cref="StatusCode"/>.
    /// </summary>
    public interface IStatusCodeActionResult : IActionResult
    {
        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        int? StatusCode { get; }
    }
}
