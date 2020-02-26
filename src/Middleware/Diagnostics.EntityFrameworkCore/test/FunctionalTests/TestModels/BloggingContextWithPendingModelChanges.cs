// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Tests
{
    public class BloggingContextWithPendingModelChanges : BloggingContext
    {
        public BloggingContextWithPendingModelChanges(DbContextOptions options)
            : base(options)
        { }

        [DbContext(typeof(BloggingContextWithPendingModelChanges))]
        public class BloggingModelSnapshot : ModelSnapshot
        {
            protected override void BuildModel(ModelBuilder modelBuilder)
            {
            }
        }

        [DbContext(typeof(BloggingContextWithPendingModelChanges))]
        [Migration("111111111111111_MigrationOne")]
        public partial class MigrationOne : Migration
        {
            protected override void Up(MigrationBuilder migrationBuilder)
            { }
        }
    }
}