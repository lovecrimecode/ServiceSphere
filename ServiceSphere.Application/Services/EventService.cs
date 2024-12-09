using System.Threading.Tasks;
using ServiceSphere.Application.Interfaces;
using ServiceSphere.Domain.Entities;
using ServiceSphere.Application.Interfaces;
using ServiceSphere.Domain.InterfacesRepos;

namespace ServiceSphere.Application.Services
{

    public class EventService : IEventService
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
           // eventItem.CreatedBy = "System";
            await _eventRepository.AddAsync(eventItem);
            // Manejo de excepciones puede ser agregado aquí.
        }

        public async Task<bool> UpdateEventAsync(Event eventItem)
        {
            // Realizar la actualización en el repositorio
            try
            {
                // Intentar actualizar el evento
                await _eventRepository.UpdateAsync(eventItem);

                // Si no hay excepción, la actualización fue exitosa
                return true;
            }
            catch
            {
                // Si ocurre un error, devolvemos false
                return false;
            }
        }


            public async Task<bool> DeleteEventAsync(int id)
        {
            await _eventRepository.DeleteAsync(id);  // No capturamos ningún resultado
            return true;  // Devolver true, asumiendo que la eliminación fue exitosa
        }

    }
}