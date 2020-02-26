﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Filters;
using Moq;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.Filters
{
    public class PageViewDataAttributeFilterFactoryTest
    {
        [Fact]
        public void CreateInstance_CreatesFilter()
        {
            // Arrange
            var properties = new LifecycleProperty[]
            {
                new LifecycleProperty(),
                new LifecycleProperty(),
            };
            var filterFactory = new PageViewDataAttributeFilterFactory(properties);

            // Act
            var result = filterFactory.CreateInstance(Mock.Of<IServiceProvider>());

            // Assert
            var filter = Assert.IsType<PageViewDataAttributeFilter>(result);
            Assert.Same(properties, filter.Properties);
        }
    }
}
