// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Xml.Linq;

namespace Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel
{
    /// <summary>
    /// A class that can deserialize an <see cref="XElement"/> that represents the serialized version
    /// of an <see cref="AuthenticatedEncryptorDescriptor"/>.
    /// </summary>
    public sealed class AuthenticatedEncryptorDescriptorDeserializer : IAuthenticatedEncryptorDescriptorDeserializer
    {
        /// <summary>
        /// Imports the <see cref="AuthenticatedEncryptorDescriptor"/> from serialized XML.
        /// </summary>
        public IAuthenticatedEncryptorDescriptor ImportFromXml(XElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            // <descriptor>
            //   <encryption algorithm="..." />
            //   <validation algorithm="..." /> <!-- only if not GCM -->
            //   <masterKey requiresEncryption="true">...</masterKey>
            // </descriptor>

            var configuration = new AuthenticatedEncryptorConfiguration();

            var encryptionElement = element.Element("encryption");
            configuration.EncryptionAlgorithm = (EncryptionAlgorithm)Enum.Parse(typeof(EncryptionAlgorithm), (string)encryptionElement.Attribute("algorithm"));

            // only read <validation> if not GCM
            if (!AuthenticatedEncryptorFactory.IsGcmAlgorithm(configuration.EncryptionAlgorithm))
            {
                var validationElement = element.Element("validation");
                configuration.ValidationAlgorithm = (ValidationAlgorithm)Enum.Parse(typeof(ValidationAlgorithm), (string)validationElement.Attribute("algorithm"));
            }

            Secret masterKey = ((string)element.Elements("masterKey").Single()).ToSecret();
            return new AuthenticatedEncryptorDescriptor(configuration, masterKey);
        }
    }
}
