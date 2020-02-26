// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Internal;
using Microsoft.AspNetCore.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Tests
{
    public class LibuvTransportFactoryTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1337)]
        public void StartWithNonPositiveThreadCountThrows(int threadCount)
        {
            var options = new LibuvTransportOptions { ThreadCount = threadCount };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                new LibuvTransportFactory(Options.Create(options), new LifetimeNotImplemented(), Mock.Of<ILoggerFactory>()));

            Assert.Equal("threadCount", exception.ParamName);
        }

        [Fact]
        public void LoggerCategoryNameIsLibuvTransportNamespace()
        {
            var mockLoggerFactory = new Mock<ILoggerFactory>();
            new LibuvTransportFactory(Options.Create<LibuvTransportOptions>(new LibuvTransportOptions()), new LifetimeNotImplemented(), mockLoggerFactory.Object);
            mockLoggerFactory.Verify(factory => factory.CreateLogger("Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv"));
        }
    }
}
