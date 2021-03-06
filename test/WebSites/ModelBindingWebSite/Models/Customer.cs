// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Mvc;

namespace ModelBindingWebSite.Models
{
    public class Customer : Person
    {
        public int Id { get; set; }

        [FromBody]
        public Department Department { get; set; }
    }
}