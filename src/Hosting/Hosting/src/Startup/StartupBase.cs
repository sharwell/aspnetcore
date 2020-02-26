// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Hosting
{
    public abstract class StartupBase : IStartup
    {
        public abstract void Configure(IApplicationBuilder app);

        IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            ConfigureServices(services);
            return CreateServiceProvider(services);
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
        }

        public virtual IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }
    }

    public abstract class StartupBase<TBuilder> : StartupBase
    {
        private readonly IServiceProviderFactory<TBuilder> _factory;

        public StartupBase(IServiceProviderFactory<TBuilder> factory)
        {
            _factory = factory;
        }

        public override IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            var builder = _factory.CreateBuilder(services);
            ConfigureContainer(builder);
            return _factory.CreateServiceProvider(builder);
        }

        public virtual void ConfigureContainer(TBuilder builder)
        {
        }
    }
}