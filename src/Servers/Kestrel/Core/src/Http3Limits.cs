// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.AspNetCore.Server.Kestrel.Core
{
    public class Http3Limits
    {
        private int _headerTableSize = 4096;
        private int _maxRequestHeaderFieldSize = 8192;

        /// <summary>
        /// Limits the size of the header compression table, in octets, the HPACK decoder on the server can use.
        /// <para>
        /// Value must be greater than 0, defaults to 4096
        /// </para>
        /// </summary>
        public int HeaderTableSize
        {
            get => _headerTableSize;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, CoreStrings.GreaterThanZeroRequired);
                }

                _headerTableSize = value;
            }
        }

        /// <summary>
        /// Indicates the size of the maximum allowed size of a request header field sequence. This limit applies to both name and value sequences in their compressed and uncompressed representations.
        /// <para>
        /// Value must be greater than 0, defaults to 8192
        /// </para>
        /// </summary>
        public int MaxRequestHeaderFieldSize
        {
            get => _maxRequestHeaderFieldSize;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, CoreStrings.GreaterThanZeroRequired);
                }

                _maxRequestHeaderFieldSize = value;
            }
        }
    }
}
