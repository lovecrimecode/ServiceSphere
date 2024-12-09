using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;

namespace ServiceSphere.Infrastructure.Models
{
    public class GuestModel
    {
        [Key]  // Define la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuestId { get; set; }
        public string Name { get; set; }
        public bool IsAttending { get; set; }

        public int? EventId { get; set; } // Relación opcional
        public Event? Event { get; set; }
    }
}
