// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers
{
    internal class CharArrayBufferSource : ICharBufferSource
    {
        public static readonly CharArrayBufferSource Instance = new CharArrayBufferSource();

        public char[] Rent(int bufferSize) => new char[bufferSize];

        public void Return(char[] buffer)
        {
            // Do nothing.
        }
    }
}
