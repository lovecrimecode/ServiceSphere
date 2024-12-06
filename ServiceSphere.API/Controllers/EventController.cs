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
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService) // Cambiado a IEventService para seguir la interfaz
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventModel>>> GetEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventModel>> GetEvent(int id)
        {
            var eventItem = await _eventService.GetEventByIdAsync(id);
            if (eventItem == null) return NotFound("Event not found.");
            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent(EventModel eventModel)
        {
            if (eventModel == null || string.IsNullOrWhiteSpace(eventModel.Name))
                return BadRequest("Invalid event data.");

            var eventItem = new Event
            {
                Name = eventModel.Name,
                Date = eventModel.Date,
                Location = eventModel.Location,
                Budget = eventModel.Budget
            };

            await _eventService.AddEventAsync(eventItem);
            return CreatedAtAction(nameof(GetEvent), new { id = eventItem.Id }, eventItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent(int id, EventModel eventModel)
        {
            if (eventModel == null || string.IsNullOrWhiteSpace(eventModel.Name))
                return BadRequest("Invalid event data.");

            var eventItem = new Event
            {
                Id = id,
                Name = eventModel.Name,
                Date = eventModel.Date,
                Location = eventModel.Location,
                Budget = eventModel.Budget
            };

            var success = await _eventService.UpdateEventAsync(eventItem);
            if (!success) return NotFound("Event not found for update.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var success = await _eventService.DeleteEventAsync(id);
            if (!success) return NotFound("Event not found for deletion.");

            return NoContent();
        }
    }
}