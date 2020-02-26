// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Blazor.Server.AutoRebuild
{
    internal static class StreamProtocolExtensions
    {
        public static async Task WriteStringAsync(this Stream stream, string str)
        {
            var utf8Bytes = Encoding.UTF8.GetBytes(str);
            await stream.WriteAsync(BitConverter.GetBytes(utf8Bytes.Length), 0, 4);
            await stream.WriteAsync(utf8Bytes, 0, utf8Bytes.Length);
        }

        public static async Task WriteDateTimeAsync(this Stream stream, DateTime value)
        {
            var ticksBytes = BitConverter.GetBytes(value.Ticks);
            await stream.WriteAsync(ticksBytes, 0, 8);
        }

        public static async Task<bool> ReadBoolAsync(this Stream stream)
        {
            var responseBuf = new byte[1];
            await stream.ReadAsync(responseBuf, 0, 1);
            return responseBuf[0] == 1;
        }

        public static async Task<int> ReadIntAsync(this Stream stream)
        {
            var responseBuf = new byte[4];
            await stream.ReadAsync(responseBuf, 0, 4);
            return BitConverter.ToInt32(responseBuf, 0);
        }
    }
}
