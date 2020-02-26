// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using XmlFormattersWebSite.Models;

namespace XmlFormattersWebSite
{
    public class PersonWrapperProviderFactory : IWrapperProviderFactory
    {
        public IWrapperProvider GetProvider(WrapperProviderContext context)
        {
            if (context.DeclaredType == typeof(Person))
            {
                return new PersonWrapperProvider();
            }

            return null;
        }
    }
}