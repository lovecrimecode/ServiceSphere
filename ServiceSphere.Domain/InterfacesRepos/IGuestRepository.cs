using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceSphere.Domain.Core;
using ServiceSphere.Domain.Entities;

namespace ServiceSphere.Domain.InterfacesRepos
{
    public interface IGuestRepository : IRepository<Guest>
    {
        Task<IEnumerable<Guest>> GetAllGuestsAsync();
        Task<Guest> GetGuestByIdAsync(int id);
        Task AddGuestAsync(Guest GuestItem);
        void UpdateGuest(Guest GuestItem);
        void DeleteGuest(int id);
    }
}
