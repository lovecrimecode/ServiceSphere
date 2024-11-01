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
    public class ServicesController : ControllerBase
    {
        private readonly ServiceSphereDbContext _context;

        public ServicesController(ServiceSphereDbContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

/*        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetService(int id)
        {
            var serviceItem = await _context.Services.FindAsync(id);

            if (serviceItem == null)
            {
                return NotFound();
            }
            return serviceItem;
        }*/

        // POST: api/services
        [HttpPost]
        public async Task<ActionResult<Service>> CreateService(Service serviceItem)
        {
            _context.Services.Add(serviceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServices), new { id = serviceItem.ServiceId }, serviceItem);
        } //ARREGALR A GETSERVICE (nameof(GetService)

        // PUT: api/services/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, Service serviceItem)
        {
            if (id != serviceItem.ServiceId)
                return BadRequest();

            _context.Entry(serviceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var serviceItem = await _context.Services.FindAsync(id);
            if (serviceItem == null)
                return NotFound();

            _context.Services.Remove(serviceItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiceId == id);
        }
    }
}
