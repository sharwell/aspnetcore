// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Hosting
{
    public static class WebHostDefaults
    {
        public static readonly string ApplicationKey = "applicationName";
        public static readonly string StartupAssemblyKey = "startupAssembly";
        public static readonly string HostingStartupAssembliesKey = "hostingStartupAssemblies";
        public static readonly string HostingStartupExcludeAssembliesKey = "hostingStartupExcludeAssemblies";

        public static readonly string DetailedErrorsKey = "detailedErrors";
        public static readonly string EnvironmentKey = "environment";
        public static readonly string WebRootKey = "webroot";
        public static readonly string CaptureStartupErrorsKey = "captureStartupErrors";
        public static readonly string ServerUrlsKey = "urls";
        public static readonly string ContentRootKey = "contentRoot";
        public static readonly string PreferHostingUrlsKey = "preferHostingUrls";
        public static readonly string PreventHostingStartupKey = "preventHostingStartup";
        public static readonly string SuppressStatusMessagesKey = "suppressStatusMessages";

        public static readonly string ShutdownTimeoutKey = "shutdownTimeoutSeconds";
        public static readonly string StaticWebAssetsKey = "staticWebAssets";
    }
}
