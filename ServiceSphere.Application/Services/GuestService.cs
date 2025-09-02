using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Domain.InterfacesRepos;

namespace ServiceSphere.Application.Services
{

    public class GuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await _guestRepository.GetAllAsync();
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await _guestRepository.GetByIdAsync(id);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task AddGuestAsync(Guest guestItem)
        {
            //guestItem.CreatedBy = "System";
            await _guestRepository.AddAsync(guestItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task UpdateGuestAsync(Guest guestItem)
        {
            await _guestRepository.UpdateAsync(guestItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task DeleteGuestAsync(int id)
        {
            await _guestRepository.DeleteAsync(id);
            // Manejo de excepciones puede ser agregado aquí.
        }
    }
}