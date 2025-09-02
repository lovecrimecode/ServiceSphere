using ServiceSphere.Domain.Entities;
using ServiceSphere.Infrastructure.Core;
using ServiceSphere.Domain.InterfacesRepos;
using ServiceSphere.Infrastructure.Context;

namespace ServiceSphere.Infrastructure.Repositories
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ServiceSphereDbContext context) : base(context) { }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await GetAllAsync(); // Utiliza el método genérico.
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await GetByIdAsync(id); // Utiliza el método genérico.
        }

        public async Task AddServiceAsync(Service serviceItem)
        {
            await AddAsync(serviceItem); // Utiliza el método genérico.
        }

        public void UpdateService(Service serviceItem)
        {
            UpdateAsync(serviceItem); // Utiliza el método genérico.
        }

        public void DeleteService(int id)
        {
            DeleteAsync(id); // Utiliza el método genérico.
        }
    }
}