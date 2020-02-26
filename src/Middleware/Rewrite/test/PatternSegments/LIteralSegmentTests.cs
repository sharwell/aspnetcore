// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Rewrite.PatternSegments;
using Xunit;

namespace Microsoft.AspNetCore.Rewrite.Tests.PatternSegments
{
    public class LiteralSegmentTests
    {
        [Fact]
        public void LiteralSegment_AssertSegmentIsCorrect()
        {
            // Arrange
            var segement = new LiteralSegment("foo");

            // Act
            var results = segement.Evaluate(null, null, null);

            // Assert
            Assert.Equal("foo", results);
        }
    }
}
