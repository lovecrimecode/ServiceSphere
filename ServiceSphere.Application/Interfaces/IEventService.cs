using ServiceSphere.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.Application.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task AddEventAsync(Event eventItem);
        Task<bool> UpdateEventAsync(Event eventItem);
        Task<bool> DeleteEventAsync(int id);
    }
}