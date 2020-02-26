// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace Microsoft.AspNetCore.Http.Features
{
    /// <summary>
    /// Default implementation of <see cref="IResponseCookiesFeature"/>.
    /// </summary>
    public class ResponseCookiesFeature : IResponseCookiesFeature
    {
        // Lambda hoisted to static readonly field to improve inlining https://github.com/dotnet/roslyn/issues/13624
        private readonly static Func<IFeatureCollection, IHttpResponseFeature> _nullResponseFeature = f => null;

        private FeatureReferences<IHttpResponseFeature> _features;
        private IResponseCookies _cookiesCollection;

        /// <summary>
        /// Initializes a new <see cref="ResponseCookiesFeature"/> instance.
        /// </summary>
        /// <param name="features">
        /// <see cref="IFeatureCollection"/> containing all defined features, including this
        /// <see cref="IResponseCookiesFeature"/> and the <see cref="IHttpResponseFeature"/>.
        /// </param>
        public ResponseCookiesFeature(IFeatureCollection features)
            : this(features, builderPool: null)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ResponseCookiesFeature"/> instance.
        /// </summary>
        /// <param name="features">
        /// <see cref="IFeatureCollection"/> containing all defined features, including this
        /// <see cref="IResponseCookiesFeature"/> and the <see cref="IHttpResponseFeature"/>.
        /// </param>
        /// <param name="builderPool">The <see cref="ObjectPool{T}"/>, if available.</param>
        public ResponseCookiesFeature(IFeatureCollection features, ObjectPool<StringBuilder> builderPool)
        {
            if (features == null)
            {
                throw new ArgumentNullException(nameof(features));
            }

            _features.Initalize(features);
        }

        private IHttpResponseFeature HttpResponseFeature => _features.Fetch(ref _features.Cache, _nullResponseFeature);

        /// <inheritdoc />
        public IResponseCookies Cookies
        {
            get
            {
                if (_cookiesCollection == null)
                {
                    var headers = HttpResponseFeature.Headers;
                    _cookiesCollection = new ResponseCookies(headers, null);
                }

                return _cookiesCollection;
            }
        }
    }
}
