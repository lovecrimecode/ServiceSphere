using ServiceSphere.Domain.Entities;
using ServiceSphere.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Domain.InterfacesRepos
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
