using Microsoft.AspNetCore.Mvc;
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

        public GuestsController(GuestService guestService)
        {
            _guestService = guestService;
        }

        // GET: Guests
        public async Task<IActionResult> Index()
        {
            var guests = await _guestService.GetAllGuestsAsync();
            return View(guests);
        }

        // GET: Guests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var guestItem = await _guestService.GetGuestByIdAsync(id.Value);
            if (guestItem == null) return NotFound("Guest not found.");
            return View(guestItem);
        }

        // GET: Guests/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuestModel guestModel)
        {
            if (ModelState.IsValid)
            {
                await _guestService.AddGuestAsync(new Guest
                {
                    Name = guestModel.Name,
                    IsAttending = guestModel.IsAttending
                });
                return RedirectToAction(nameof(Index));
            }
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
                IsAttending = guestItem.IsAttending
            };
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