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
    public class EventModel
    {
        [Key]  // Define la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public decimal Budget { get; set; }
        public int? OrganizerId { get; set; } // Relación opcional
        public Organizer? Organizer { get; set; } // Navegación
        public List<Service>? Services { get; set; }
        public List<int>? ServiceIds { get; set; } // Relación opcional
        public List<Guest>? Guests { get; set; } // Relación opcional
    }
}
