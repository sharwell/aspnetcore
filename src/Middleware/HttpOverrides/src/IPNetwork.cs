﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net;

namespace Microsoft.AspNetCore.HttpOverrides
{
    public class IPNetwork
    {
        public IPNetwork(IPAddress prefix, int prefixLength)
        {
            Prefix = prefix;
            PrefixLength = prefixLength;
            PrefixBytes = Prefix.GetAddressBytes();
            Mask = CreateMask();
        }

        public IPAddress Prefix { get; }

        private byte[] PrefixBytes { get; }

        /// <summary>
        /// The CIDR notation of the subnet mask 
        /// </summary>
        public int PrefixLength { get; }

        private byte[] Mask { get; }

        public bool Contains(IPAddress address)
        {
            if (Prefix.AddressFamily != address.AddressFamily)
            {
                return false;
            }

            var addressBytes = address.GetAddressBytes();
            for (int i = 0; i < PrefixBytes.Length && Mask[i] != 0; i++)
            {
                if (PrefixBytes[i] != (addressBytes[i] & Mask[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private byte[] CreateMask()
        {
            var mask = new byte[PrefixBytes.Length];
            int remainingBits = PrefixLength;
            int i = 0;
            while (remainingBits >= 8)
            {
                mask[i] = 0xFF;
                i++;
                remainingBits -= 8;
            }
            if (remainingBits > 0)
            {
                mask[i] = (byte)(0xFF << (8 - remainingBits));
            }

            return mask;
        }
    }
}
