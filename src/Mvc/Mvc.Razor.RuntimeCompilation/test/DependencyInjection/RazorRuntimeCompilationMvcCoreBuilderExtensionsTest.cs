// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Xunit;

namespace Microsoft.Extensions.DependencyInjection
{
    public class RazorRuntimeCompilationMvcCoreBuilderExtensionsTest
    {
        [Fact]
        public void AddServices_ReplacesRazorViewCompiler()
        {
            // Arrange
            var services = new ServiceCollection()
                .AddSingleton<IViewCompilerProvider, DefaultViewCompilerProvider>();

            // Act
            RazorRuntimeCompilationMvcCoreBuilderExtensions.AddServices(services);

            // Assert
            var serviceDescriptor = Assert.Single(services, service => service.ServiceType == typeof(IViewCompilerProvider));
            Assert.Equal(typeof(RuntimeViewCompilerProvider), serviceDescriptor.ImplementationType);
        }
    }
}
