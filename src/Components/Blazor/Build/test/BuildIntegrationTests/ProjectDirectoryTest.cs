// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;

namespace Microsoft.AspNetCore.Blazor.Build
{
    public class ProjectDirectoryTest
    {
        [Fact]
        public void ProjectDirectory_IsNotSetToBePreserved()
        {
            // Arrange
            using var project = ProjectDirectory.Create("standalone");

            // Act & Assert
            // This flag is only meant for local debugging and should not be set when checking in.
            Assert.False(project.PreserveWorkingDirectory);
        }
    }
}
