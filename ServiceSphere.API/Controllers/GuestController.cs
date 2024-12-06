using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Application.Services;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Models;
using ServiceSphere.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly GuestService _guestService;

        public GuestsController(GuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestModel>>> GetGuests()
        {
            var guests = await _guestService.GetAllGuestsAsync();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestModel>> GetGuest(int id)
        {
            var guestItem = await _guestService.GetGuestByIdAsync(id);
            if (guestItem == null) return NotFound("Guest not found.");
            return Ok(guestItem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGuest(GuestModel guestModel)
        {
            if (guestModel == null || string.IsNullOrWhiteSpace(guestModel.Name))
                return BadRequest("Invalid guest data.");

            var guestItem = new Guest
            {
                Name = guestModel.Name,
                IsAttending = guestModel.IsAttending
            };

            await _guestService.AddGuestAsync(guestItem);
            return CreatedAtAction(nameof(GetGuest), new { id = guestItem.GuestId }, guestItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGuest(int id, GuestModel guestModel)
        {
            if (guestModel == null || string.IsNullOrWhiteSpace(guestModel.Name))
                return BadRequest("Invalid guest data.");

            var guestItem = new Guest
            {
                GuestId = id,
                Name = guestModel.Name,
                IsAttending = guestModel.IsAttending
            };

            await _guestService.UpdateGuestAsync(guestItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            await _guestService.DeleteGuestAsync(id);
            return NoContent();
        }
    }
}