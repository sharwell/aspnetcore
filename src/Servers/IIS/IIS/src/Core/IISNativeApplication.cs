// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;

namespace Microsoft.AspNetCore.Server.IIS.Core
{
    internal class IISNativeApplication
    {
        private readonly IntPtr _nativeApplication;

        public IISNativeApplication(IntPtr nativeApplication)
        {
            _nativeApplication = nativeApplication;
        }

        public void StopIncomingRequests()
        {
            NativeMethods.HttpStopIncomingRequests(_nativeApplication);
        }

        public void StopCallsIntoManaged()
        {
            NativeMethods.HttpStopCallsIntoManaged(_nativeApplication);
        }

        public void RegisterCallbacks(
            NativeMethods.PFN_REQUEST_HANDLER requestHandler,
            NativeMethods.PFN_SHUTDOWN_HANDLER shutdownHandler,
            NativeMethods.PFN_DISCONNECT_HANDLER disconnectHandler,
            NativeMethods.PFN_ASYNC_COMPLETION onAsyncCompletion,
            NativeMethods.PFN_REQUESTS_DRAINED_HANDLER requestDrainedHandler,
            IntPtr requestContext,
            IntPtr shutdownContext)
        {
            NativeMethods.HttpRegisterCallbacks(
                _nativeApplication,
                requestHandler,
                shutdownHandler,
                disconnectHandler,
                onAsyncCompletion,
                requestDrainedHandler,
                requestContext,
                shutdownContext);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~IISNativeApplication()
        {
            // If this finalize is invoked, try our best to block all calls into managed.
            StopCallsIntoManaged();
        }
    }
}
