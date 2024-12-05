using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Domain.Core;

namespace ServiceSphere.Domain.InterfacesRepos
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task AddEventAsync(Event eventItem);
        void UpdateEvent(Event eventItem);
        void DeleteEvent(int id);
    }

}
