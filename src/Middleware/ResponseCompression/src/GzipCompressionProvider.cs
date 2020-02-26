// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.IO.Compression;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.ResponseCompression
{
    /// <summary>
    /// GZIP compression provider.
    /// </summary>
    public class GzipCompressionProvider : ICompressionProvider
    {
        /// <summary>
        /// Creates a new instance of GzipCompressionProvider with options.
        /// </summary>
        /// <param name="options"></param>
        public GzipCompressionProvider(IOptions<GzipCompressionProviderOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            Options = options.Value;
        }

        private GzipCompressionProviderOptions Options { get; }

        /// <inheritdoc />
        public string EncodingName { get; } = "gzip";

        /// <inheritdoc />
        public bool SupportsFlush => true;

        /// <inheritdoc />
        public Stream CreateStream(Stream outputStream)
            => new GZipStream(outputStream, Options.Level, leaveOpen: true);
    }
}
