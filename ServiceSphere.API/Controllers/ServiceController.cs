using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Application.Interfaces;
using ServiceSphere.Application.Services;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServicesController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceModel>>> GetServices()
        {
            var services = await _serviceService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceModel>> GetService(int id)
        {
            var serviceItem = await _serviceService.GetServiceByIdAsync(id);
            if (serviceItem == null) return NotFound("Service not found.");
            return Ok(serviceItem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateService(ServiceModel serviceModel)
        {
            if (serviceModel == null || string.IsNullOrWhiteSpace(serviceModel.Name))
                return BadRequest("Invalid service data.");

            var serviceItem = new Service
            {
                Name = serviceModel.Name,
                Cost = serviceModel.Cost,
                Description = serviceModel.Description
            };

            await _serviceService.AddServiceAsync(serviceItem);
            return CreatedAtAction(nameof(GetService), new { id = serviceItem.ServiceId }, serviceItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateService(int id, ServiceModel serviceModel)
        {
            if (serviceModel == null || string.IsNullOrWhiteSpace(serviceModel.Name))
                return BadRequest("Invalid service data.");

            var serviceItem = new Service
            {
                ServiceId = id,
                Name = serviceModel.Name,
                Cost = serviceModel.Cost,
                Description = serviceModel.Description
            };

            await _serviceService.UpdateServiceAsync(serviceItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return NoContent();
        }
    }
}