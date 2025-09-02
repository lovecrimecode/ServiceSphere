using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceSphere.Domain.Core;
using ServiceSphere.Domain.Entities;

namespace ServiceSphere.Domain.InterfacesRepos
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
