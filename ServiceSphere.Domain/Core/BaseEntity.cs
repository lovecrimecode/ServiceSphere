using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Domain.Core
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
