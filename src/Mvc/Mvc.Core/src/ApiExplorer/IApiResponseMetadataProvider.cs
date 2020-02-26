// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Microsoft.AspNetCore.Mvc.ApiExplorer
{
    /// <summary>
    /// Provides a return type, status code and a set of possible content types returned by a
    /// successful execution of the action.
    /// </summary>
    public interface IApiResponseMetadataProvider : IFilterMetadata
    {
        /// <summary>
        /// Gets the optimistic return type of the action.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Gets the HTTP status code of the response.
        /// </summary>
        int StatusCode { get; }

        /// <summary>
        /// Configures a collection of allowed content types which can be produced by the action.
        /// </summary>
        void SetContentTypes(MediaTypeCollection contentTypes);
    }
}