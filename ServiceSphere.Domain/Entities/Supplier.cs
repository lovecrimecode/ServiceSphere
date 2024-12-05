﻿using ServiceSphere.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }

        // Relationships
        public ICollection<Service> Services { get; set; }
    }
}
