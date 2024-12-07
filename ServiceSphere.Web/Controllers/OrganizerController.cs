using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;//
using System.Threading.Tasks;//
using ServiceSphere.Domain.Entities;
using ServiceSphere.Application.Services;
using ServiceSphere.Domain;
using ServiceSphere.Infrastructure.Persistence.Context;
using ServiceSphere.Infrastructure.Models;
namespace ServiceSphere.Web.Controllers
{
    public class OrganizersController : Controller
    {
        private readonly OrganizerService _organizerService;

        public OrganizersController(OrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        // GET: Organizers
        public async Task<IActionResult> Index()
        {
            var organizers = await _organizerService.GetAllOrganizersAsync();
            return View(organizers); // Retorna la lista de organizadores.
        }

        // GET: Organizers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var organizerItem = await _organizerService.GetOrganizerByIdAsync(id.Value);
            if (organizerItem == null) return NotFound("Organizer not found."); // Retorna 404 si no se encuentra.

            return View(organizerItem); // Retorna el organizador encontrado.
        }

        // GET: Organizers/Create
        public IActionResult Create()
        {
            return View(); // Retorna la vista para crear un nuevo organizador.
        }

        [HttpPost]
        public async Task<ActionResult> Create(Organizer organizerModel)
        {
            if (ModelState.IsValid)
            {
                await _organizerService.AddOrganizerAsync(new Organizer
                {
                    Name = organizerModel.Name,
                    Phone = organizerModel.Phone,
                    Email = organizerModel.Email
                });
                return RedirectToAction(nameof(Index));
            }
            return View(organizerModel);
        }

        // GET: Organizers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var organizerItem = await _organizerService.GetOrganizerByIdAsync(id.Value);
            if (organizerItem == null) return NotFound("Organizer not found.");

            var organizerModel = new OrganizerModel
            {
                OrganizerId = organizerItem.Id,
                Name = organizerItem.Name,
                Phone = organizerItem.Phone,
                Email = organizerItem.Email
            };
            return View(organizerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrganizerModel organizerModel)
        {
            if (ModelState.IsValid)
            {
                await _organizerService.UpdateOrganizerAsync(new Organizer
                {
                    OrganizerId = organizerModel.OrganizerId,
                    Name = organizerModel.Name,
                    Phone = organizerModel.Phone,
                    Email = organizerModel.Email
                });
                return RedirectToAction(nameof(Index)); // Redirige a la lista de eventos
            }
            return View(organizerModel);
        }

                    // GET: Organizers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
                if (id == null) return NotFound();

                var organizerItem = await _organizerService.GetOrganizerByIdAsync(id.Value);

                if (organizerItem == null) return NotFound("Organizer not found.");

                return View(organizerItem); // Retorna la vista de confirmación para eliminar el organizador.
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _organizerService.DeleteOrganizerAsync(id); // Eliminar organizador.
            return RedirectToAction(nameof(Index)); // Redirige a la lista de organizadores.
        }
    }
}