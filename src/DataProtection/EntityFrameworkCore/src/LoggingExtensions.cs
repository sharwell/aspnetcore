// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.Extensions.Logging
{
    internal static class LoggingExtensions
    {
        private static readonly Action<ILogger, string, Exception> _anExceptionOccurredWhileParsingKeyXml;
        private static readonly Action<ILogger, string, string, Exception> _savingKeyToDbContext;

        static LoggingExtensions()
        {
            _anExceptionOccurredWhileParsingKeyXml = LoggerMessage.Define<string>(
                eventId: new EventId(1, "ExceptionOccurredWhileParsingKeyXml"),
                logLevel: LogLevel.Warning,
                formatString: "An exception occurred while parsing the key xml '{Xml}'.");
            _savingKeyToDbContext = LoggerMessage.Define<string, string>(
                eventId: new EventId(2, "SavingKeyToDbContext"),
                logLevel: LogLevel.Debug,
                formatString: "Saving key '{FriendlyName}' to '{DbContext}'.");
        }

        public static void LogExceptionWhileParsingKeyXml(this ILogger logger, string keyXml, Exception exception)
            => _anExceptionOccurredWhileParsingKeyXml(logger, keyXml, exception);

        public static void LogSavingKeyToDbContext(this ILogger logger, string friendlyName, string contextName)
            => _savingKeyToDbContext(logger, friendlyName, contextName, null);
    }
}
