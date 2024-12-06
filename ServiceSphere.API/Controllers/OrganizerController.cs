using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Application.Services;
using ServiceSphere.Application.Interfaces;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizersController : ControllerBase
    {
        private readonly OrganizerService _organizerService;

        public OrganizersController(OrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizer>>> GetOrganizers()
        {
            var organizers = await _organizerService.GetAllOrganizersAsync();
            return Ok(organizers); // Retorna la lista de organizadores.
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organizer>> GetOrganizer(int id)
        {
            var organizer = await _organizerService.GetOrganizerByIdAsync(id);
            if (organizer == null)
                return NotFound("Organizer not found."); // Retorna 404 si no se encuentra.

            return Ok(organizer); // Retorna el organizador encontrado.
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrganizer(Organizer organizer)
        {
            if (organizer == null || string.IsNullOrWhiteSpace(organizer.Name))
                return BadRequest("Invalid organizer data."); // Validación simple.

            await _organizerService.AddOrganizerAsync(organizer); // Agregar organizador.
            return CreatedAtAction(nameof(GetOrganizer), new { id = organizer.Id }, organizer); // Retorna 201 Created.
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrganizer(int id, Organizer organizer)
        {
            if (organizer == null || string.IsNullOrWhiteSpace(organizer.Name))
                return BadRequest("Invalid organizer data."); // Validación simple.

            organizer.Id = id; // Asignar el ID del organizador a actualizar.
            await _organizerService.UpdateOrganizerAsync(organizer); // Actualizar organizador.
            return NoContent(); // Retorna 204 No Content.
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrganizer(int id)
        {
            await _organizerService.DeleteOrganizerAsync(id); // Eliminar organizador.
            return NoContent(); // Retorna 204 No Content.
        }
    }
}