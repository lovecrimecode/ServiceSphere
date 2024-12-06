using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Application.Services;
using ServiceSphere.Domain;
using ServiceSphere.Infrastructure.Persistence.Context;

namespace PaqJet.Web.Controllers
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
            return View();
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();

        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        private bool EventrExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}