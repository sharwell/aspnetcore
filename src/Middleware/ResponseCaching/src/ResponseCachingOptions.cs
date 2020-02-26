// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;

namespace Microsoft.AspNetCore.ResponseCaching
{
    public class ResponseCachingOptions
    {
        /// <summary>
        /// The size limit for the response cache middleware in bytes. The default is set to 100 MB.
        /// </summary>
        public long SizeLimit { get; set; } = 100 * 1024 * 1024;

        /// <summary>
        /// The largest cacheable size for the response body in bytes. The default is set to 64 MB.
        /// </summary>
        public long MaximumBodySize { get; set; } = 64 * 1024 * 1024;

        /// <summary>
        /// <c>true</c> if request paths are case-sensitive; otherwise <c>false</c>. The default is to treat paths as case-insensitive.
        /// </summary>
        public bool UseCaseSensitivePaths { get; set; } = false;

        /// <summary>
        /// For testing purposes only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ISystemClock SystemClock { get; set; } = new SystemClock();
    }
}
