using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Application.Services;
using ServiceSphere.Infrastructure.Models;
using ServiceSphere.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.Web.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ServiceService _serviceService;

        public ServicesController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            var services = await _serviceService.GetAllServicesAsync();

            // Convertir los servicios a ServiceModel
            var serviceModels = services.Select(service => new ServiceModel
            {
                ServiceId = service.ServiceId,
                Name = service.Name,
                Cost = service.Cost,
                Description = service.Description
            }).ToList();

            return View(serviceModels); // Pasar ServiceModel en lugar de Service
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceService.AddServiceAsync(new Service
                {
                    Name = serviceModel.Name,
                    Cost = serviceModel.Cost,
                    Description = serviceModel.Description
                });
                return RedirectToAction(nameof(Index));
            }
            return View(serviceModel);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var serviceItem = await _serviceService.GetServiceByIdAsync(id.Value);
            if (serviceItem == null) return NotFound("Service not found.");

            var serviceModel = new ServiceModel
            {
                ServiceId = serviceItem.ServiceId,
                Name = serviceItem.Name,
                Cost = serviceItem.Cost,
                Description = serviceItem.Description
            };

            return View(serviceModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceService.UpdateServiceAsync(new Service
                {
                    ServiceId = serviceModel.ServiceId,
                    Name = serviceModel.Name,
                    Cost = serviceModel.Cost,
                    Description = serviceModel.Description
                });
                return RedirectToAction(nameof(Index));
            }
            return View(serviceModel);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var serviceItem = await _serviceService.GetServiceByIdAsync(id.Value);
            if (serviceItem == null) return NotFound("Service not found.");
            return View(serviceItem);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}