// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.AspNetCore.Routing.Patterns;

namespace Microsoft.AspNetCore.Routing.Template
{
    /// <summary>
    /// The parsed representation of an inline constraint in a route parameter.
    /// </summary>
    public class InlineConstraint
    {
        /// <summary>
        /// Creates a new instance of <see cref="InlineConstraint"/>.
        /// </summary>
        /// <param name="constraint">The constraint text.</param>
        public InlineConstraint(string constraint)
        {
            if (constraint == null)
            {
                throw new ArgumentNullException(nameof(constraint));
            }

            Constraint = constraint;
        }

        public InlineConstraint(RoutePatternParameterPolicyReference other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            Constraint = other.Content;
        }

        /// <summary>
        /// Gets the constraint text.
        /// </summary>
        public string Constraint { get; }
    }
}