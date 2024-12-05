using ServiceSphere.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Domain.Entities
{
    public class Guest : BaseEntity
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public bool IsAttending { get; set; }

        // Relationships
        public int EventId { get; set; }
        public Event Event { get; set; }
    }

}
