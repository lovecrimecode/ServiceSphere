using ServiceSphere.Infrastructure.Data;
using ServiceSphere.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiceSphere.Application
{
    public class EventService
    {
        private readonly ServiceSphereDbContext _context;

        public EventService(ServiceSphereDbContext context)
        {
            _context = context;
        }

        public async Task<Event> CreateEventAsync(Event newEvent) {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            return await _context.Events.Include(e => e.Guests).ToListAsync();
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            _context.Events.Update(updatedEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
            }
        }
       
        public async Task GenerateBudgetReportAsync(int Id)
        {
            // Placeholder for future asynchronous logic
            await Task.CompletedTask;
        }
    }
}