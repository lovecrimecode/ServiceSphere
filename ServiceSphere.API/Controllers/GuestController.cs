﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.Api.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
        {
            return await _context.Guests.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
                return NotFound();

            return guest;
        }

        [HttpPost]
        public async Task<ActionResult<Guest>> CreateGuest(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGuest), new { id = guest.Id }, guest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, Guest guest)
        {
            if (id != guest.Id)
                return BadRequest();

            _context.Entry(guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
                return NotFound();

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
