﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace Microsoft.Extensions.DependencyInjection
{
    public class NewtonsoftJsonMvcBuilderExtensionsTest
    {
        [Fact]
        public void AddNewtonsoftJson_ConfiguresOptions()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddMvc()
                .AddNewtonsoftJson((options) =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            // Assert
            Assert.Single(services, d => d.ServiceType == typeof(IConfigureOptions<MvcNewtonsoftJsonOptions>));
        }
    }
}
