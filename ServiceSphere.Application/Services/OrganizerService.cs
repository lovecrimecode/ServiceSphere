using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Domain.InterfacesRepos;

namespace ServiceSphere.Application.Services
{
    public class OrganizerService
    {
        private readonly IOrganizerRepository _organizerRepository;

        public OrganizerService(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        public async Task<IEnumerable<Organizer>> GetAllOrganizersAsync()
        {
            return await _organizerRepository.GetAllAsync();
        }

        public async Task<Organizer> GetOrganizerByIdAsync(int id)
        {
            return await _organizerRepository.GetByIdAsync(id);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task AddOrganizerAsync(Organizer organizerItem)
        {
            await _organizerRepository.AddAsync(organizerItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task UpdateOrganizerAsync(Organizer organizerItem)
        {
            await _organizerRepository.UpdateAsync(organizerItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task DeleteOrganizerAsync(int id)
        {
            await _organizerRepository.DeleteAsync(id);
            // Manejo de excepciones puede ser agregado aquí.
        }
    }
}
