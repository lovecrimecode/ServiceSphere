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
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierService _supplierService;

        public SuppliersController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return Ok(suppliers); // Retorna la lista de proveedores.
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
                return NotFound("Supplier not found."); // Retorna 404 si no se encuentra.

            return Ok(supplier); // Retorna el proveedor encontrado.
        }

        [HttpPost]
        public async Task<ActionResult> CreateSupplier(Supplier supplier)
        {
            if (supplier == null || string.IsNullOrWhiteSpace(supplier.Name))
                return BadRequest("Invalid supplier data."); // Validación simple.

            await _supplierService.AddSupplierAsync(supplier); // Agregar proveedor.
            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.Id }, supplier); // Retorna 201 Created.
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSupplier(int id, Supplier supplier)
        {
            if (supplier == null || string.IsNullOrWhiteSpace(supplier.Name))
                return BadRequest("Invalid supplier data."); // Validación simple.

            supplier.Id = id; // Asignar el ID del proveedor a actualizar.
            await _supplierService.UpdateSupplierAsync(supplier); // Actualizar proveedor.
            return NoContent(); // Retorna 204 No Content.
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(int id)
        {
            await _supplierService.DeleteSupplierAsync(id); // Eliminar proveedor.
            return NoContent(); // Retorna 204 No Content.
        }
    }
}