using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Domain.Entities; // Asegúrate de que este espacio de nombres sea correcto
using ServiceSphere.Infrastructure.Data; // Asegúrate de que este espacio de nombres sea correcto
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiceSphere.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly ServiceSphereDbContext _context;

        public EventsController(ServiceSphereDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events); // Devuelve una vista con la lista de eventos
        }

        // GET: Events/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return NotFound(); // Retorna un 404 si el ID no es válido

            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
                return NotFound(); // Retorna un 404 si el evento no se encuentra

            return View(eventItem); // Devuelve la vista con los detalles del evento
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View(); // Devuelve la vista para crear un nuevo evento
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event eventItem)
        {
            if (ModelState.IsValid) // Verifica que el modelo sea válido
            {
                _context.Events.Add(eventItem); // Agrega el nuevo evento al contexto
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                return RedirectToAction(nameof(Index)); // Redirige a la lista de eventos
            }
            return View(eventItem); // Si el modelo no es válido, retorna la vista con el evento
        }

        // GET: Events/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound(); // Retorna un 404 si el ID no es válido

            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
                return NotFound(); // Retorna un 404 si el evento no se encuentra

            return View(eventItem); // Devuelve la vista para editar el evento
        }

        // POST: Events/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event eventItem)
        {
            if (id != eventItem.Id) // Verifica que el ID coincida
                return NotFound(); // Retorna un 404 si el ID no coincide

            if (ModelState.IsValid) // Verifica que el modelo sea válido
            {
                try
                {
                    _context.Events.Update(eventItem); // Actualiza el evento en el contexto
                    await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(eventItem.Id))
                        return NotFound(); // Retorna un 404 si el evento no existe
                    else
                        throw; // Relanza la excepción si hay un problema
                }
                return RedirectToAction(nameof(Index)); // Redirige a la lista de eventos
            }
            return View(eventItem); // Si el modelo no es válido, retorna la vista con el evento
        }

        // GET: Events/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return NotFound(); // Retorna un 404 si el ID no es válido

            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
                return NotFound(); // Retorna un 404 si el evento no se encuentra

            return View(eventItem); // Devuelve la vista para confirmar la eliminación
        }

        // POST: Events/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem != null)
            {
                _context.Events.Remove(eventItem); // Elimina el evento del contexto
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            }
            return RedirectToAction(nameof(Index)); // Redirige a la lista de eventos
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id); // Verifica si el evento existe
        }
    }
}
