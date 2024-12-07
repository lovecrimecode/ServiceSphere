using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;//
using System.Threading.Tasks;//
using ServiceSphere.Domain.Entities;
using ServiceSphere.Application.Services;
using ServiceSphere.Domain;
using ServiceSphere.Infrastructure.Persistence.Context;
using ServiceSphere.Infrastructure.Models;

namespace ServiceSphere.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventService _eventService;

        public EventsController(EventService eventService)
        {
            _eventService = eventService; // Inyecta el servicio directamente
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllEventsAsync(); // Obtiene todos los eventos
            return View(events); // Retorna la vista con la lista de eventos
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var eventItem = await _eventService.GetEventByIdAsync(id.Value);
            if (eventItem == null) return NotFound("Event not found.");

            return View(eventItem); // Retorna la vista de detalles del evento
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View(); // Retorna la vista para crear un nuevo evento
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                await _eventService.AddEventAsync(new Event
                {
                    Name = eventModel.Name,
                    Date = eventModel.Date,
                    Location = eventModel.Location,
                    Budget = eventModel.Budget
                });
                return RedirectToAction(nameof(Index)); // Redirige a la lista de eventos
            }
            return View(eventModel); // Retorna a la vista si hay errores en el modelo
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var eventItem = await _eventService.GetEventByIdAsync(id.Value);
            if (eventItem == null) return NotFound("Event not found.");

            var eventModel = new EventModel
            {
                EventId = eventItem.EventId,
                Name = eventItem.Name,
                Date = eventItem.Date,
                Location = eventItem.Location,
                Budget = eventItem.Budget
            };
            return View(eventModel); // Retorna la vista para editar el evento
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                await _eventService.UpdateEventAsync(new Event
                {
                    EventId = eventModel.EventId,
                    Name = eventModel.Name,
                    Date = eventModel.Date,
                    Location = eventModel.Location,
                    Budget = eventModel.Budget
                });
                return RedirectToAction(nameof(Index)); // Redirige a la lista de eventos
            }
            return View(eventModel); // Retorna a la vista si hay errores en el modelo
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var eventItem = await _eventService.GetEventByIdAsync(id.Value);
            if (eventItem == null) return NotFound("Event not found.");

            return View(eventItem); // Retorna la vista de confirmación para eliminar el evento
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventService.DeleteEventAsync(id); // Elimina el evento
            return RedirectToAction(nameof(Index)); // Redirige a la lista de eventos
        }

        private bool EventExists(int id)
        {
            return _eventService.GetEventByIdAsync(id).Result != null; // Verifica si el evento existe
        }
    }
}