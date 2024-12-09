using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Core;
using ServiceSphere.Domain.InterfacesRepos;
using ServiceSphere.Infrastructure.Context;

namespace ServiceSphere.Infrastructure.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ServiceSphereDbContext context) : base(context) { }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await GetAllAsync(); // Utiliza el método genérico.
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await GetByIdAsync(id); // Utiliza el método genérico.
        }

        public async Task AddEventAsync(Event eventItem)
        {
            await AddAsync(eventItem); // Utiliza el método genérico.
        }

        public void UpdateEvent(Event eventItem)
        {
            UpdateAsync(eventItem); // Utiliza el método genérico.
        }

        public void DeleteEvent(int id)
        {
            DeleteAsync(id); // Utiliza el método genérico.
        }
    }
}