using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Domain.InterfacesRepos;

namespace ServiceSphere.Application.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _supplierRepository.GetAllAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _supplierRepository.GetByIdAsync(id);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task AddSupplierAsync(Supplier supplierItem)
        {
            //supplierItem.CreatedBy = "System";
            await _supplierRepository.AddAsync(supplierItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task UpdateSupplierAsync(Supplier supplierItem)
        {
            //supplierItem.UpdatedBy = "System";
            await _supplierRepository.UpdateAsync(supplierItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task DeleteSupplierAsync(int id)
        {
            await _supplierRepository.DeleteAsync(id);
            // Manejo de excepciones puede ser agregado aquí.
        }
    }
}
