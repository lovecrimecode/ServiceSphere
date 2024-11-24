using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Infrastructure.Models
{
    public class GuestModel
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public bool IsAttending { get; set; }
    }
}
