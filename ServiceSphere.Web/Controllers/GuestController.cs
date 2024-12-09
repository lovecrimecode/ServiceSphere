using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceSphere.Application.Interfaces;
using ServiceSphere.Application.Services;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.Web.Controllers
{
    public class GuestsController : Controller
    {
        private readonly GuestService _guestService;
        private readonly IEventService _eventService;

        public GuestsController(GuestService guestService, IEventService eventService)
        {
            _guestService = guestService;
            _eventService = eventService;  // Inicializa el servicio de eventos
        }

        // GET: Guests
        public async Task<IActionResult> Index()
        {
            var guests = await _guestService.GetAllGuestsAsync();
            return View(guests);
        }

        // GET: Guests/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Events = new SelectList(await _eventService.GetAllEventsAsync(), "EventId", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuestModel guestModel)
        {
            if (ModelState.IsValid)
            {
                var newGuest = new Guest
                {
                    Name = guestModel.Name,
                    IsAttending = guestModel.IsAttending,
                    EventId = guestModel.EventId // Puede ser null
                };

                await _guestService.AddGuestAsync(newGuest);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Events = new SelectList(await _eventService.GetAllEventsAsync(), "EventId", "Title", guestModel.EventId);
            return View(guestModel);
        }

        // GET: Guests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var guestItem = await _guestService.GetGuestByIdAsync(id.Value);
            if (guestItem == null) return NotFound("Guest not found.");

            var guestModel = new GuestModel
            {
                GuestId = guestItem.GuestId,
                Name = guestItem.Name,
                IsAttending = guestItem.IsAttending,
                EventId = guestItem.EventId
            };
            ViewBag.Events = new SelectList(await _eventService.GetAllEventsAsync(), "EventId", "Title", guestModel.EventId);
            return View(guestModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GuestModel guestModel)
        {
            if (ModelState.IsValid)
            {
                await _guestService.UpdateGuestAsync(new Guest
                {
                    GuestId = guestModel.GuestId,
                    Name = guestModel.Name,
                    IsAttending = guestModel.IsAttending
                });
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Events = new SelectList(await _eventService.GetAllEventsAsync(), "EventId", "Title", guestModel.EventId);
            return View(guestModel);
        }

        // GET: Guests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var guestItem = await _guestService.GetGuestByIdAsync(id.Value);
            if (guestItem == null) return NotFound("Guest not found.");
            return View(guestItem);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _guestService.DeleteGuestAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}