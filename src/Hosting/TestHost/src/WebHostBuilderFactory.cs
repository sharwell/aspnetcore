// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Microsoft.AspNetCore.TestHost
{
    public static class WebHostBuilderFactory
    {
        public static IWebHostBuilder CreateFromAssemblyEntryPoint(Assembly assembly, string[] args)
        {
            var factory = HostFactoryResolver.ResolveWebHostBuilderFactory<IWebHostBuilder>(assembly);
            return factory?.Invoke(args);
        }

        public static IWebHostBuilder CreateFromTypesAssemblyEntryPoint<T>(string[] args) =>
            CreateFromAssemblyEntryPoint(typeof(T).Assembly, args);
    }
}
