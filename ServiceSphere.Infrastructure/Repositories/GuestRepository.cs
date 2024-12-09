using ServiceSphere.Domain.Entities;
using ServiceSphere.Domain.InterfacesRepos;
using ServiceSphere.Infrastructure.Core;
using ServiceSphere.Infrastructure.Persistence.Context;

namespace ServiceSphere.Infrastructure.Repositories
{
    public class GuestRepository : BaseRepository<Guest>, IGuestRepository
    {
        public GuestRepository(ServiceSphereDbContext context) : base(context) { }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await GetAllAsync(); // Utiliza el método genérico.
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await GetByIdAsync(id); // Utiliza el método genérico.
        }

        public async Task AddGuestAsync(Guest guestItem)
        {
            await AddAsync(guestItem); // Utiliza el método genérico.
        }

        public void UpdateGuest(Guest guestItem)
        {
            UpdateAsync(guestItem); // Utiliza el método genérico.
        }

        public void DeleteGuest(int id)
        {
            DeleteAsync(id); // Utiliza el método genérico.
        }
    }
}