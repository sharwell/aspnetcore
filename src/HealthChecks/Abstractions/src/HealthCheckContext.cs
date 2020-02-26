// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.Extensions.Diagnostics.HealthChecks
{
    public sealed class HealthCheckContext
    {
        /// <summary>
        /// Gets or sets the <see cref="HealthCheckRegistration"/> of the currently executing <see cref="IHealthCheck"/>.
        /// </summary>
        public HealthCheckRegistration Registration { get; set; }
    }
}
