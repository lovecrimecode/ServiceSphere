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
    public class Event //: BaseEntity
    {
        [Key]  // Define la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Configura la columna para autoincrementar
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public decimal Budget { get; set; }


        // Relationships
        public int? OrganizerId { get; set; }
        public Organizer? Organizer { get; set; }
        public ICollection<Guest>? Guests { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
