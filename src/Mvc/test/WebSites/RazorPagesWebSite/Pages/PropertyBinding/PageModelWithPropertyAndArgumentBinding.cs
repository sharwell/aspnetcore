// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWebSite
{
    public class PageModelWithPropertyAndArgumentBinding : PageModel
    {
        [ModelBinder]
        public UserModel UserModel { get; set; }

        public int Id { get; set; }

        public void OnGet(int id)
        {
            Id = id;
        }

        public void OnPost(int id)
        {
            Id = id;
        }
    }
}
