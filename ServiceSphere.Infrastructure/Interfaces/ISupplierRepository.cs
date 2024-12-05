using ServiceSphere.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Infrastructure.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task AddSupplierAsync(Supplier supplierItem);
        void UpdateSupplier(Supplier supplierItem);
        void DeleteSupplier(int id);
    }
}
