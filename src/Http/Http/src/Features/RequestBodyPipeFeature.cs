// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Http.Features
{
    public class RequestBodyPipeFeature : IRequestBodyPipeFeature
    {
        private PipeReader _internalPipeReader;
        private Stream _streamInstanceWhenWrapped;
        private HttpContext _context;

        public RequestBodyPipeFeature(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            _context = context;
        }

        public PipeReader Reader
        {
            get
            {
                if (_internalPipeReader == null ||
                    !ReferenceEquals(_streamInstanceWhenWrapped, _context.Request.Body))
                {
                    _streamInstanceWhenWrapped = _context.Request.Body;
                    _internalPipeReader = PipeReader.Create(_context.Request.Body);

                    _context.Response.OnCompleted((self) =>
                    {
                        ((PipeReader)self).Complete();
                        return Task.CompletedTask;
                    }, _internalPipeReader);
                }

                return _internalPipeReader;
            }
        }
    }
}
