using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Domain
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public decimal Budget { get; set; }

        // Relationships
        public List<Guest> Guests { get; set; }
        public List<Service> Services { get; set; }
    }
}
