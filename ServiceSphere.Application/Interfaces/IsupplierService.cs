using ServiceSphere.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSphere.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task AddSupplierAsync(Supplier eventItem);
        Task<bool> UpdateSupplierAsync(Supplier eventItem);
        Task<bool> DeleteSupplierAsync(int id);
    }
}