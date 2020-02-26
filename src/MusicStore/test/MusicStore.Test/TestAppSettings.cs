// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Options;

namespace MusicStore.Test
{
    public class TestAppSettings : IOptions<AppSettings>
    {
        private readonly AppSettings _appSettings;

        public TestAppSettings(bool storeInCache = true)
        {
            _appSettings = new AppSettings()
            {
                SiteTitle = "ASP.NET MVC Music Store",
                CacheDbResults = storeInCache
            };
        }

        public AppSettings Value
        {
            get
            {
                return _appSettings;
            }
        }
    }
}
