// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.AspNetCore.MiddlewareAnalysis
{
    public class AnalysisStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                var wrappedBuilder = new AnalysisBuilder(builder);
                next(wrappedBuilder);

                // The caller doesn't call build on our new builder, they call it on the original. Add this
                // default middleware to the end. Compare with AnalysisBuilder.Build();

                // Add one maker at the end before the default 404 middleware (or any fancy Join middleware).
                builder.UseMiddleware<AnalysisMiddleware>("EndOfPipeline");
            };
        }
    }
}
