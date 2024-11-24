using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Core;
using ServiceSphere.Infrastructure.Interfaces;
using ServiceSphere.Infrastructure.Persistence.Context;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(ServiceSphereDbContext context) : base(context) { }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task<Event> GetEventByIdAsync(int id)
    {
        return await _context.Events.FindAsync(id);
    }

    public async Task AddEventAsync(Event eventItem)
    {
        await _context.Events.AddAsync(eventItem);
        await _context.SaveChangesAsync();
    }

    public void UpdateEvent(Event eventItem)
    {
        _context.Events.Update(eventItem);
        _context.SaveChanges();
    }

    public void DeleteEvent(int id)
    {
        var eventItem = _context.Events.Find(id);
        if (eventItem != null)
        {
            _context.Events.Remove(eventItem);
            _context.SaveChanges();
        }
    }
}
