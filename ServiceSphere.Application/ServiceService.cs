using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Domain.Interfaces;
using ServiceSphere.Infrastructure.Repositories;

namespace ServiceSphere.Application.Services
{
    public class ServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _serviceRepository.GetAllAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _serviceRepository.GetByIdAsync(id);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task AddServiceAsync(Service serviceItem)
        {
            await _serviceRepository.AddAsync(serviceItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task UpdateServiceAsync(Service serviceItem)
        {
            await _serviceRepository.UpdateAsync(serviceItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task DeleteServiceAsync(int id)
        {
            await _serviceRepository.DeleteAsync(id);
            // Manejo de excepciones puede ser agregado aquí.
        }
    }
}
    }
}