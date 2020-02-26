// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Azure.Storage.Blob;
using Xunit;

namespace Microsoft.AspNetCore.DataProtection.AzureStorage
{
    public class AzureDataProtectionBuilderExtensionsTest
    {
        [Fact]
        public void PersistKeysToAzureBlobStorage_UsesAzureBlobXmlRepository()
        {
            // Arrange
            var container = new CloudBlobContainer(new Uri("http://www.example.com"));
            var serviceCollection = new ServiceCollection();
            var builder = serviceCollection.AddDataProtection();

            // Act
            builder.PersistKeysToAzureBlobStorage(container, "keys.xml");
            var services = serviceCollection.BuildServiceProvider();

            // Assert
            var options = services.GetRequiredService<IOptions<KeyManagementOptions>>();
            Assert.IsType<AzureBlobXmlRepository>(options.Value.XmlRepository);
        }
    }
}
