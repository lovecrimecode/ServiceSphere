using ServiceSphere.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Domain.Entities
{
    public class Supplier //: BaseEntity
    {
        [Key]  // Define la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Configura la columna para autoincrementar
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }


        // Relationships
        public ICollection<Service> Services { get; set; }
    }
}
