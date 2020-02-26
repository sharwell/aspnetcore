// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// A <see cref="ValidationAttribute"/> that compares two properties
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ComparePropertyAttribute : CompareAttribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BlazorCompareAttribute"/>.
        /// </summary>
        /// <param name="otherProperty">The property to compare with the current property.</param>
        public ComparePropertyAttribute(string otherProperty)
            : base(otherProperty)
        {
        }

        /// <inheritdoc />
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationResult = base.IsValid(value, validationContext);
            if (validationResult == ValidationResult.Success)
            {
                return validationResult;
            }

            return new ValidationResult(validationResult.ErrorMessage, new[] { validationContext.MemberName });
        }
    }
}

