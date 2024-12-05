﻿using ServiceSphere.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Domain.Entities
{
    public class Service : BaseEntity
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        // Relationships
        public List<Supplier> Suppliers { get; set; }
        public List<Event> Events { get; set; }
    }
}
