using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Domain.Interfaces;

namespace ServiceSphere.Application.Services
{

    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _eventRepository.GetByIdAsync(id);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task AddEventAsync(Event eventItem)
        {
            await _eventRepository.AddAsync(eventItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task UpdateEventAsync(Event eventItem)
        {
            await _eventRepository.UpdateAsync(eventItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task DeleteEventAsync(int id)
        {
            await _eventRepository.DeleteAsync(id);
            // Manejo de excepciones puede ser agregado aquí.
        }
    }
}