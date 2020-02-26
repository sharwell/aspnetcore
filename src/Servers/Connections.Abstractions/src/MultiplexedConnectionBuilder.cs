// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Connections
{
    public class MultiplexedConnectionBuilder : IMultiplexedConnectionBuilder
    {
        private readonly IList<Func<MultiplexedConnectionDelegate, MultiplexedConnectionDelegate>> _components = new List<Func<MultiplexedConnectionDelegate, MultiplexedConnectionDelegate>>();

        public IServiceProvider ApplicationServices { get; }

        public MultiplexedConnectionBuilder(IServiceProvider applicationServices)
        {
            ApplicationServices = applicationServices;
        }

        public IMultiplexedConnectionBuilder Use(Func<MultiplexedConnectionDelegate, MultiplexedConnectionDelegate> middleware)
        {
            _components.Add(middleware);
            return this;
        }

        public MultiplexedConnectionDelegate Build()
        {
            MultiplexedConnectionDelegate app = features =>
            {
                return Task.CompletedTask;
            };

            foreach (var component in _components.Reverse())
            {
                app = component(app);
            }

            return app;
        }
    }
}
