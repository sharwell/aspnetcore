﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Server.IntegrationTesting
{
    /// <summary>
    /// Factory to create an appropriate deployer based on <see cref="DeploymentParameters"/>.
    /// </summary>
    public class ApplicationDeployerFactory
    {
        /// <summary>
        /// Creates a deployer instance based on settings in <see cref="DeploymentParameters"/>.
        /// </summary>
        /// <param name="deploymentParameters"></param>
        /// <param name="loggerFactory"></param>
        /// <returns></returns>
        public static ApplicationDeployer Create(DeploymentParameters deploymentParameters, ILoggerFactory loggerFactory)
        {
            if (deploymentParameters == null)
            {
                throw new ArgumentNullException(nameof(deploymentParameters));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            switch (deploymentParameters.ServerType)
            {
                case ServerType.IISExpress:
                case ServerType.IIS:
                    throw new NotSupportedException("Use Microsoft.AspNetCore.Server.IntegrationTesting.IIS package and IISApplicationDeployerFactory for IIS support.");
                case ServerType.HttpSys:
                case ServerType.Kestrel:
                    return new SelfHostDeployer(deploymentParameters, loggerFactory);
                case ServerType.Nginx:
                    return new NginxDeployer(deploymentParameters, loggerFactory);
                default:
                    throw new NotSupportedException(
                        string.Format("Found no deployers suitable for server type '{0}' with the current runtime.",
                        deploymentParameters.ServerType)
                        );
            }
        }
    }
}
