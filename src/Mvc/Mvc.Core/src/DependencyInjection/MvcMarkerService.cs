// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// A marker class used to determine if all the MVC services were added
    /// to the <see cref="IServiceCollection"/> before MVC is configured.
    /// </summary>
    internal class MvcMarkerService
    {
    }
}
