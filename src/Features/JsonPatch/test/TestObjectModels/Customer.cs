// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.JsonPatch.Internal
{
    internal class Customer
    {
        private string _name;
        private int _age;

        public Customer(string name, int age)
        {
            _name = name;
            _age = age;
        }
    }
}
