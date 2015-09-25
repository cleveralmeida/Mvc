// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace Microsoft.AspNet.Mvc.ModelBinding.Validation
{
    /// <summary>
    /// Provides an implementation of <see cref="IExcludeTypeValidationFilter"/> which can filter
    /// based on a type full name.
    /// </summary>
    public class DefaultTypeNameBasedExcludeFilter : IExcludeTypeValidationFilter
    {
        /// <summary>
        /// Creates a new instance of <see cref="DefaultTypeNameBasedExcludeFilter"/>
        /// </summary>
        /// <param name="typeFullName">Fully qualified name of the type which needs to be excluded.</param>
        public DefaultTypeNameBasedExcludeFilter(string typeFullName)
        {
            if (typeFullName == null)
            {
                throw new ArgumentNullException(nameof(typeFullName));
            }

            ExcludedTypeName = typeFullName;
        }

        /// <summary>
        /// Gets the type full name which is excluded from validation.
        /// </summary>
        public string ExcludedTypeName { get; }

        /// <inheritdoc />
        public bool IsTypeExcluded(Type propertyType)
        {
            if (propertyType == null)
            {
                throw new ArgumentNullException(nameof(propertyType));
            }

            return CheckIfTypeNameMatches(propertyType);
        }

        private bool CheckIfTypeNameMatches(Type type)
        {
            if (type == null)
            {
                return false;
            }

            if (string.Equals(type.FullName, ExcludedTypeName, StringComparison.Ordinal))
            {
                return true;
            }

            return CheckIfTypeNameMatches(type.GetTypeInfo().BaseType);
        }
    }
}
