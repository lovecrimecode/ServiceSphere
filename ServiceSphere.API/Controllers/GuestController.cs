using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Domain;
using ServiceSphere.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using ServiceSphere.Infrastructure.Data;

namespace ServiceSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly ServiceSphereDbContext _context;

        public GuestsController(ServiceSphereDbContext context)
        {
            _context = context;
        }

        // GET: api/Guests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
        {
            return await _context.Guests.ToListAsync();
        }

        /*        // GET: api/Guests/5
                [HttpGet("{id}")]
                public async Task<ActionResult<Event>> GetGuest(int id)
                {
                    var guestItem = await _context.Guests.FindAsync(id);

                    if (guestItem == null)
                    {
                        return NotFound();
                    }
                    return guestItem;
                }*/

        // POST: api/guests
        [HttpPost]
        public async Task<ActionResult<Guest>> CreateGuest(Guest guestItem)
        {
            _context.Guests.Add(guestItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGuests), new { id = guestItem.GuestId }, guestItem);
        } //ARREGALR A GETSERVICE (nameof(GetGuest)

        // PUT: api/guests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, Guest guestItem)
        {
            if (id != guestItem.GuestId)
                return BadRequest();

            _context.Entry(guestItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var guestItem = await _context.Guests.FindAsync(id);
            if (guestItem == null)
                return NotFound();

            _context.Guests.Remove(guestItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuestExists(int id)
        {
            return _context.Guests.Any(e => e.GuestId == id);
        }
    }
}
