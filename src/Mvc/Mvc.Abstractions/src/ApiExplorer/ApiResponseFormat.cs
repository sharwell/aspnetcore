// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc.Formatters;

namespace Microsoft.AspNetCore.Mvc.ApiExplorer
{
    /// <summary>
    /// Possible format for an <see cref="ApiResponseType"/>.
    /// </summary>
    public class ApiResponseFormat
    {
        /// <summary>
        /// Gets or sets the formatter used to output this response.
        /// </summary>
        public IOutputFormatter Formatter { get; set; }

        /// <summary>
        /// Gets or sets the media type of the response.
        /// </summary>
        public string MediaType { get; set; }
    }
}
