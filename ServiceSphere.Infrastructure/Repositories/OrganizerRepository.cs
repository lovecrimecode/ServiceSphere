using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Core;
using ServiceSphere.Infrastructure.Interfaces;
using ServiceSphere.Infrastructure.Persistence.Context;

namespace ServiceSphere.Infrastructure.Repositories
{
    public class OrganizerRepository : BaseRepository<Organizer>, IOrganizerRepository
    {
        public OrganizerRepository(ServiceSphereDbContext context) : base(context) { }

        public async Task<IEnumerable<Organizer>> GetAllOrganizersAsync()
        {
            return await GetAllAsync(); // Utiliza el método genérico.
        }

        public async Task<Organizer> GetOrganizerByIdAsync(int id)
        {
            return await GetByIdAsync(id); // Utiliza el método genérico.
        }

        public async Task AddOrganizerAsync(Organizer organizerItem)
        {
            await AddAsync(organizerItem); // Utiliza el método genérico.
        }

        public void UpdateOrganizer(Organizer organizerItem)
        {
            UpdateAsync(organizerItem); // Utiliza el método genérico.
        }

        public void DeleteOrganizer(int id)
        {
            DeleteAsync(id); // Utiliza el método genérico.
        }
    }
}