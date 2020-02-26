// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace FormatterWebSite.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult Index([FromBody]DummyClass dummyObject)
        {
            return Content(dummyObject.SampleInt.ToString());
        }

        [HttpPost]
        public DummyClass GetDummyClass(int sampleInput)
        {
            return new DummyClass { SampleInt = sampleInput };
        }

        [HttpPost]
        public bool CheckIfDummyIsNull([FromBody] DummyClass dummy)
        {
            return dummy != null;
        }

        [HttpPost]
        public DummyClass GetDerivedDummyClass(int sampleInput)
        {
            return new DerivedDummyClass
            {
                SampleInt = sampleInput,
                SampleIntInDerived = 50
            };
        }
    }
}