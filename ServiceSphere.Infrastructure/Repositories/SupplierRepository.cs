using ServiceSphere.Domain.Entities;
using ServiceSphere.Domain.InterfacesRepos;
using ServiceSphere.Infrastructure.Context;
using ServiceSphere.Infrastructure.Core;

namespace ServiceSphere.Infrastructure.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ServiceSphereDbContext context) : base(context) { }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await GetAllAsync(); // Utiliza el método genérico.
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await GetByIdAsync(id); // Utiliza el método genérico.
        }

        public async Task AddSupplierAsync(Supplier supplierItem)
        {
            await AddAsync(supplierItem); // Utiliza el método genérico.
        }

        public void UpdateSupplier(Supplier supplierItem)
        {
            UpdateAsync(supplierItem); // Utiliza el método genérico.
        }

        public void DeleteSupplier(int id)
        {
            DeleteAsync(id); // Utiliza el método genérico.
        }
    }
}