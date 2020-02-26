// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text;

namespace Microsoft.Extensions.ObjectPool
{
    public static class ObjectPoolProviderExtensions
    {
        public static ObjectPool<StringBuilder> CreateStringBuilderPool(this ObjectPoolProvider provider)
        {
            return provider.Create<StringBuilder>(new StringBuilderPooledObjectPolicy());
        }

        public static ObjectPool<StringBuilder> CreateStringBuilderPool(
            this ObjectPoolProvider provider,
            int initialCapacity,
            int maximumRetainedCapacity)
        {
            var policy = new StringBuilderPooledObjectPolicy()
            {
                InitialCapacity = initialCapacity,
                MaximumRetainedCapacity = maximumRetainedCapacity,
            };

            return provider.Create<StringBuilder>(policy);
        }
    }
}
