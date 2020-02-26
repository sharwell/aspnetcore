// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.Extensions.ObjectPool
{
    public class LeakTrackingObjectPoolProvider : ObjectPoolProvider
    {
        private readonly ObjectPoolProvider _inner;

        public LeakTrackingObjectPoolProvider(ObjectPoolProvider inner)
        {
            if (inner == null)
            {
                throw new ArgumentNullException(nameof(inner));
            }

            _inner = inner;
        }

        public override ObjectPool<T> Create<T>(IPooledObjectPolicy<T> policy)
        {
            var inner = _inner.Create<T>(policy);
            return new LeakTrackingObjectPool<T>(inner);
        }
    }
}
