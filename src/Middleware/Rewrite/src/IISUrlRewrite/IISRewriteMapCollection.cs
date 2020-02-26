// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Rewrite.IISUrlRewrite
{
    internal class IISRewriteMapCollection : IEnumerable<IISRewriteMap>
    {
        private readonly Dictionary<string, IISRewriteMap> _rewriteMaps = new Dictionary<string, IISRewriteMap>();

        public void Add(IISRewriteMap rewriteMap)
        {
            if (rewriteMap != null)
            {
                _rewriteMaps[rewriteMap.Name] = rewriteMap;
            }
        }

        public int Count => _rewriteMaps.Count;

        public IISRewriteMap this[string key]
        {
            get
            {
                IISRewriteMap value;
                return _rewriteMaps.TryGetValue(key, out value) ? value : null;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _rewriteMaps.Values.GetEnumerator();
        }

        public IEnumerator<IISRewriteMap> GetEnumerator()
        {
            return _rewriteMaps.Values.GetEnumerator();
        }
    }
}