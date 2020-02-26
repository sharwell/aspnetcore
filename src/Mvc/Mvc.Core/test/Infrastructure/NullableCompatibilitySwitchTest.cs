// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    public class NullableCompatibilitySwitchTest
    {
        [Fact]
        public void Constructor_WithName_IsValueSetIsFalse()
        {
            // Arrange & Act
            var @switch = new NullableCompatibilitySwitch<bool>("TestProperty");

            // Assert
            Assert.Null(@switch.Value);
            Assert.False(@switch.IsValueSet);
        }

        [Fact]
        public void ValueNonInterface_SettingValueToNull_SetsIsValueSetToTrue()
        {
            // Arrange
            var @switch = new NullableCompatibilitySwitch<bool>("TestProperty");

            // Act
            @switch.Value = null;

            // Assert
            Assert.Null(@switch.Value);
            Assert.True(@switch.IsValueSet);
        }

        [Fact]
        public void ValueNonInterface_SettingValue_SetsIsValueSetToTrue()
        {
            // Arrange
            var @switch = new NullableCompatibilitySwitch<bool>("TestProperty");

            // Act
            @switch.Value = false;

            // Assert
            Assert.False(@switch.Value);
            Assert.True(@switch.IsValueSet);
        }

        [Fact]
        public void ValueInterface_SettingValueToNull_SetsIsValueSetToTrue()
        {
            // Arrange
            var @switch = new NullableCompatibilitySwitch<bool>("TestProperty");

            // Act
            ((ICompatibilitySwitch)@switch).Value = null;

            // Assert
            Assert.Null(@switch.Value);
            Assert.True(@switch.IsValueSet);
        }

        [Fact]
        public void ValueInterface_SettingValue_SetsIsValueSetToTrue()
        {
            // Arrange
            var @switch = new NullableCompatibilitySwitch<bool>("TestProperty");

            // Act
            ((ICompatibilitySwitch)@switch).Value = true;

            // Assert
            Assert.True(@switch.Value);
            Assert.True(@switch.IsValueSet);
        }
    }
}
