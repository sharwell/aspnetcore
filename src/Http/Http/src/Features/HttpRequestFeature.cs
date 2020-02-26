// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;

namespace Microsoft.AspNetCore.Http.Features
{
    public class HttpRequestFeature : IHttpRequestFeature
    {
        public HttpRequestFeature()
        {
            Headers = new HeaderDictionary();
            Body = Stream.Null;
            Protocol = string.Empty;
            Scheme = string.Empty;
            Method = string.Empty;
            PathBase = string.Empty;
            Path = string.Empty;
            QueryString = string.Empty;
            RawTarget = string.Empty;
        }

        public string Protocol { get; set; }
        public string Scheme { get; set; }
        public string Method { get; set; }
        public string PathBase { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string RawTarget { get; set; }
        public IHeaderDictionary Headers { get; set; }
        public Stream Body { get; set; }
    }
}