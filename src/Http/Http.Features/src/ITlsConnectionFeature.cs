// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Http.Features
{
    public interface ITlsConnectionFeature
    {
        /// <summary>
        /// Synchronously retrieves the client certificate, if any.
        /// </summary>
        X509Certificate2 ClientCertificate { get; set; }

        /// <summary>
        /// Asynchronously retrieves the client certificate, if any.
        /// </summary>
        /// <returns></returns>
        Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken);
    }
}
