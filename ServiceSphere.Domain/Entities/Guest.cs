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
    public class Guest //: BaseEntity
    {
        [Key]  // Define la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuestId { get; set; }
        public string Name { get; set; }
        public bool IsAttending { get; set; }

        // Relationships
        public int? EventId { get; set; }
        public Event? Event { get; set; }
    }

}
