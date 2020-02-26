// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http.Features;

namespace Microsoft.AspNetCore.Http
{
    public static class HttpContextServerVariableExtensions
    {
        /// <summary>
        /// Gets the value of a server variable for the current request.
        /// </summary>
        /// <param name="context">The http context for the request.</param>
        /// <param name="variableName">The name of the variable.</param>
        /// <returns>
        /// <c>null</c> if the server does not support the <see cref="IServerVariablesFeature"/> feature.
        /// May return null or empty if the variable does not exist or is not set.
        /// </returns>
        public static string GetServerVariable(this HttpContext context, string variableName)
        {
            var feature = context.Features.Get<IServerVariablesFeature>();

            if (feature == null)
            {
                return null;
            }

            return feature[variableName];
        }
    }
}
