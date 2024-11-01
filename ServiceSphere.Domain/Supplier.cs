using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Domain
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }

        // Relationships
        public List<Service> Services { get; set; }
    }
}
