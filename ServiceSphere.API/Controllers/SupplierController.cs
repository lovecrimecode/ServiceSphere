using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ServiceSphereDbContext _context;

        public SuppliersController(ServiceSphereDbContext context)
        {
            _context = context;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
                return NotFound();

            return supplier;
        }

        // POST: api/Suppliers
        [HttpPost]
        public async Task<ActionResult<Supplier>> CreateSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.SupplierId }, supplier);
        }

        // PUT: api/Suppliers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, Supplier supplier)
        {
            if (id != supplier.SupplierId)
                return BadRequest();

            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
                return NotFound();

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
