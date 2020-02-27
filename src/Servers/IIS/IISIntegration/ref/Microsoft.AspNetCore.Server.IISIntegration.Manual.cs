// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Builder
{
    public partial class IISOptions
    {
        internal bool ForwardWindowsAuthentication { [System.Runtime.CompilerServices.CompilerGeneratedAttribute]get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute]set { } }
    }
}
namespace Microsoft.AspNetCore.Server.IISIntegration
{
    internal partial class IISSetupFilter : Microsoft.AspNetCore.Hosting.IStartupFilter
    {
        internal IISSetupFilter(string pairingToken, Microsoft.AspNetCore.Http.PathString pathBase, bool isWebsocketsSupported) { }
        public System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder> Configure(System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder> next) { throw null; }
    }
}
