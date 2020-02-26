// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.AspNetCore.Authentication.WsFederation
{
    internal class TestSecurityToken : SecurityToken
    {
        public override string Id => "id";

        public override string Issuer => "issuer";

        public override SecurityKey SecurityKey => throw new NotImplementedException();

        public override SecurityKey SigningKey
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override DateTime ValidFrom => new DateTime(2008, 3, 22);

        public override DateTime ValidTo => new DateTime(2017, 3, 22);
    }
}