using ServiceSphere.Domain.Entities;
using ServiceSphere.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Domain.InterfacesRepos
{
    public interface IOrganizerRepository : IRepository<Organizer>
    {
        Task<IEnumerable<Organizer>> GetAllOrganizersAsync();
        Task<Organizer> GetOrganizerByIdAsync(int id);
        Task AddOrganizerAsync(Organizer organizerItem);
        void UpdateOrganizer(Organizer organizerItem);
        void DeleteOrganizer(int id);
    }
}
