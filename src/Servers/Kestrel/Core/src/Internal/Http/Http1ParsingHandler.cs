// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Net.Http;

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http
{
    internal readonly struct Http1ParsingHandler : IHttpRequestLineHandler, IHttpHeadersHandler
    {
        public readonly Http1Connection Connection;
        public readonly bool Trailers;

        public Http1ParsingHandler(Http1Connection connection)
        {
            Connection = connection;
            Trailers = false;
        }

        public Http1ParsingHandler(Http1Connection connection, bool trailers)
        {
            Connection = connection;
            Trailers = trailers;
        }

        public void OnHeader(ReadOnlySpan<byte> name, ReadOnlySpan<byte> value)
        {
            if (Trailers)
            {
                Connection.OnTrailer(name, value);
            }
            else
            {
                Connection.OnHeader(name, value);
            }
        }

        public void OnHeadersComplete(bool endStream)
        {
            if (Trailers)
            {
                Connection.OnTrailersComplete();
            }
            else
            {
                Connection.OnHeadersComplete();
            }
        }

        public void OnStartLine(HttpMethod method, HttpVersion version, Span<byte> target, Span<byte> path, Span<byte> query, Span<byte> customMethod, bool pathEncoded)
            => Connection.OnStartLine(method, version, target, path, query, customMethod, pathEncoded);

        public void OnStaticIndexedHeader(int index)
        {
            throw new NotImplementedException();
        }

        public void OnStaticIndexedHeader(int index, ReadOnlySpan<byte> value)
        {
            throw new NotImplementedException();
        }
    }
}
