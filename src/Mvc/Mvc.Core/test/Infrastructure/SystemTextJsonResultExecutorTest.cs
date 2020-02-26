// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    public class SystemTextJsonResultExecutorTest : JsonResultExecutorTestBase
    {
        protected override IActionResultExecutor<JsonResult> CreateExecutor(ILoggerFactory loggerFactory)
        {
            return new SystemTextJsonResultExecutor(
                Options.Create(new JsonOptions()), 
                loggerFactory.CreateLogger<SystemTextJsonResultExecutor>(),
                Options.Create(new MvcOptions()));
        }

        protected override object GetIndentedSettings()
        {
            return new JsonSerializerOptions { WriteIndented = true };
        }
    }
}
