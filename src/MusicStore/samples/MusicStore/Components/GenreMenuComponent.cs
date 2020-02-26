// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Components
{
    [ViewComponent(Name = "GenreMenu")]
    public class GenreMenuComponent : ViewComponent
    {
        public GenreMenuComponent(MusicStoreContext dbContext)
        {
            DbContext = dbContext;
        }

        private MusicStoreContext DbContext { get; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // TODO use nested sum https://github.com/aspnet/EntityFramework/issues/3792
            //.OrderByDescending(
            //    g => g.Albums.Sum(a => a.OrderDetails.Sum(od => od.Quantity)))
            
            var genres = await DbContext.Genres.Select(g => g.Name).Take(9).ToListAsync();

            return View(genres);
        }
    }
}