using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;

namespace ServiceSphere.Infrastructure.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task AddServiceAsync(Service serviceItem);
        void UpdateService(Service serviceItem);
        void DeleteService(int id);
    }
}
