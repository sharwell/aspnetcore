// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Components.Test.Helpers
{
    public class TestServiceProvider : IServiceProvider
    {
        private readonly Dictionary<Type, Func<object>> _factories
            = new Dictionary<Type, Func<object>>();

        public object GetService(Type serviceType)
            => _factories.TryGetValue(serviceType, out var factory)
                ? factory()
                : null;

        internal void AddService<T>(T value)
            => _factories.Add(typeof(T), () => value);
    }
}
