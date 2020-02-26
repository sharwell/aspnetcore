// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Server.IntegrationTesting.IIS;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Server.IntegrationTesting
{
    /// <summary>
    /// Factory to create an appropriate deployer based on <see cref="DeploymentParameters"/>.
    /// </summary>
    public class IISApplicationDeployerFactory
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
                    return new IISExpressDeployer(deploymentParameters, loggerFactory);
                case ServerType.IIS:
                    return new IISDeployer(deploymentParameters, loggerFactory);
                default:
                    return ApplicationDeployerFactory.Create(deploymentParameters, loggerFactory);
            }
        }
    }
}
