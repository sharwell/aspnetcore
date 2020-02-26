﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.AspNetCore.Mvc.Filters
{
    internal readonly struct FilterCursorItem<TFilter, TFilterAsync>
    {
        public FilterCursorItem(TFilter filter, TFilterAsync filterAsync)
        {
            Filter = filter;
            FilterAsync = filterAsync;
        }

        public TFilter Filter { get; }

        public TFilterAsync FilterAsync { get; }
    }
}
