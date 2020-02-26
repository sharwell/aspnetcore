// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http3
{
    enum Http3SettingType : long
    {
        QPackMaxTableCapacity = 0x1,
        /// <summary>
        /// SETTINGS_MAX_HEADER_LIST_SIZE, default is unlimited.
        /// </summary>
        MaxHeaderListSize = 0x6,
        QPackBlockedStreams = 0x7
    }
}
