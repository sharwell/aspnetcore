// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.Primitives;

namespace HtmlGenerationWebSite
{
    public interface ISignalTokenProviderService<TKey>
    {
        IChangeToken GetToken(object key);

        void SignalToken(object key);
    }
}