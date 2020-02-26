// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using System.Text;

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    /// <summary>
    /// Creates <see cref="TextWriter"/> instances for writing to <see cref="Http.HttpResponse.Body"/>.
    /// </summary>
    public interface IHttpResponseStreamWriterFactory
    {
        /// <summary>
        /// Creates a new <see cref="TextWriter"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/>, usually <see cref="Http.HttpResponse.Body"/>.</param>
        /// <param name="encoding">The <see cref="Encoding"/>, usually <see cref="Encoding.UTF8"/>.</param>
        /// <returns>A <see cref="TextWriter"/>.</returns>
        TextWriter CreateWriter(Stream stream, Encoding encoding);
    }
}
