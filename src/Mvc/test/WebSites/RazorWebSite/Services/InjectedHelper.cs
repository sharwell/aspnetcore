// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace RazorWebSite
{
    public class InjectedHelper
    {
        public string Greet(Person person)
        {
            return "Hello " + person.Name;
        }
    }
}