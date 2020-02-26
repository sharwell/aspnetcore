// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Server.IIS
{
    public sealed class BadHttpRequestException : IOException
    {
        private BadHttpRequestException(string message, int statusCode, RequestRejectionReason reason)
            : base(message)
        {
            StatusCode = statusCode;
            Reason = reason;
        }

        public int StatusCode { get; }

        internal RequestRejectionReason Reason { get; }

        internal static void Throw(RequestRejectionReason reason)
        {
            throw GetException(reason);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static BadHttpRequestException GetException(RequestRejectionReason reason)
        {
            BadHttpRequestException ex;
            switch (reason)
            {
                case RequestRejectionReason.RequestBodyTooLarge:
                    ex = new BadHttpRequestException(CoreStrings.BadRequest_RequestBodyTooLarge, StatusCodes.Status413PayloadTooLarge, reason);
                    break;
                default:
                    ex = new BadHttpRequestException(CoreStrings.BadRequest, StatusCodes.Status400BadRequest, reason);
                    break;
            }
            return ex;
        }
    }
}
