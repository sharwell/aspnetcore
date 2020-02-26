// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilesWebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilesWebSite.Controllers
{
    public class UploadFilesController : Controller
    {
        [HttpPost("UploadFiles")]
        public async Task<object> Post(User user)
        {
            var resultUser = new
            {
                Name = user.Name,
                Age = user.Age,
                Biography = await user.ReadBiography()
            };

            return resultUser;
        }

        [HttpPost("UploadProductSpecs")]
        public object ProductSpecs(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var files = new Dictionary<string, List<string>>();
            foreach (var keyValuePair in product.Specs)
            {
                files.Add(keyValuePair.Key, keyValuePair.Value?.Select(formFile => formFile?.FileName).ToList());
            }

            return new { Name = product.Name, Specs = files };
        }
    }
}
