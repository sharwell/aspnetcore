// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Pipelines
{
    internal class PipeReaderFactory
    {
        private static readonly Action<object> _cancelReader = state => ((PipeReader)state).CancelPendingRead();

        public static PipeReader CreateFromStream(PipeOptions options, Stream stream, CancellationToken cancellationToken)
        {
            if (!stream.CanRead)
            {
                throw new NotSupportedException();
            }

            var pipe = new Pipe(options);
            _ = CopyToAsync(stream, pipe, cancellationToken);

            return pipe.Reader;
        }

        private static async Task CopyToAsync(Stream stream, Pipe pipe, CancellationToken cancellationToken)
        {
            // We manually register for cancellation here in case the Stream implementation ignores it
            using (var registration = cancellationToken.Register(_cancelReader, pipe.Reader))
            {
                try
                {
                    await stream.CopyToAsync(new PipeWriterStream(pipe.Writer), bufferSize: 4096, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    // Ignore the cancellation signal (the pipe reader is already wired up for cancellation when the token trips)
                }
                catch (Exception ex)
                {
                    pipe.Writer.Complete(ex);
                    return;
                }
                pipe.Writer.Complete();
            }
        }
    }
}
