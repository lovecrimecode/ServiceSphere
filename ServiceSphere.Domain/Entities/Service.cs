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
    public class Service //: BaseEntity
    {
        [Key]  // Define la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Configura la columna para autoincrementar
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        // Relationships
        public int? SupplierId { get; set; } // Relación opcional
        public Supplier? Supplier { get; set; } // Navegación
        public int? EventId { get; set; }
        public List<Event> Events { get; set; }
    }
}
