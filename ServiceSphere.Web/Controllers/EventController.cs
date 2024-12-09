using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;//
using System.Threading.Tasks;//
using ServiceSphere.Domain.Entities;
using ServiceSphere.Application.Services;
using ServiceSphere.Application.Interfaces;
using ServiceSphere.Domain;
using ServiceSphere.Infrastructure.Context;
using ServiceSphere.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceSphere.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly OrganizerService _organizerService;
        private readonly ServiceService _serviceService;

        public EventsController(IEventService eventService, OrganizerService organizerService, ServiceService serviceService)
        {
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
            _organizerService = organizerService ?? throw new ArgumentNullException(nameof(organizerService));
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
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
        public async Task<IActionResult> Create()
        {
            ViewBag.Organizers = new SelectList(await _organizerService.GetAllOrganizersAsync(), "OrganizerId", "Name");
            ViewBag.Services = new SelectList(await _serviceService.GetAllServicesAsync(), "ServiceId", "Name");
            return View(); // Retorna la vista para crear un nuevo evento
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                var newEvent = new Event
                {
                    Name = eventModel.Name,
                    Date = eventModel.Date,
                    Location = eventModel.Location,
                    Budget = eventModel.Budget
                };

                // Asignar los servicios si hay alguno seleccionado
                if (eventModel.ServiceIds != null)
                {
                    newEvent.Services = eventModel.ServiceIds
                        .Select(id => new Service { ServiceId = id })
                        .ToList();
                }

                await _eventService.AddEventAsync(newEvent);
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
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
                Budget = eventItem.Budget,
                OrganizerId = eventItem.OrganizerId,
                ServiceIds = eventItem.Services?.Select(s => s.ServiceId).ToList()
            };
            // Rellenar los select lists para organizar y servicios
            ViewBag.Organizers = new SelectList(await _organizerService.GetAllOrganizersAsync(), "OrganizerId", "Name", eventItem.OrganizerId);
            ViewBag.Services = new SelectList(await _serviceService.GetAllServicesAsync(), "ServiceId");

            return View(eventModel); // Retorna la vista para editar el evento
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                var newEvent = new Event
                {
                    Name = eventModel.Name,
                    Date = eventModel.Date,
                    Location = eventModel.Location,
                    Budget = eventModel.Budget,
                    OrganizerId = (int)eventModel.OrganizerId
                };

                if (eventModel.ServiceIds != null)
                {
                    newEvent.Services = eventModel.ServiceIds
                        .Select(id => new Service { ServiceId = id })
                        .ToList();
                }

                await _eventService.AddEventAsync(newEvent);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Organizers = new SelectList(await _organizerService.GetAllOrganizersAsync(), "OrganizerId", "Name");
            ViewBag.Services = new SelectList(await _serviceService.GetAllServicesAsync(), "ServiceId", "Name");
            return View(eventModel);
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