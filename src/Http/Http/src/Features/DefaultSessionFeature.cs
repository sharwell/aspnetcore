// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Http.Features
{
    /// <summary>
    /// This type exists only for the purpose of unit testing where the user can directly set the
    /// <see cref="HttpContext.Session"/> property without the need for creating a <see cref="ISessionFeature"/>.
    /// </summary>
    public class DefaultSessionFeature : ISessionFeature
    {
        public ISession Session { get; set; }
    }
}
