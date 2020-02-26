// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Rewrite.IISUrlRewrite
{
    internal class IISRewriteMap
    {
        private readonly Dictionary<string, string> _map = new Dictionary<string, string>();

        public IISRewriteMap(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }
            Name = name;
        }

        public string Name { get; }

        public string this[string key]
        {
            get
            {
                string value;
                return _map.TryGetValue(key, out value) ? value : null;
            }
            set
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException(nameof(key));
                }
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(nameof(value));
                }
                _map[key] = value;
            }
        }
    }
}