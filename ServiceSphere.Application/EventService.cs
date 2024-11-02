using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;

namespace ServiceSphere.Application.Services
{

    public class EventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Event>>("api/events");
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Event>($"api/events/{id}");
        }

        public async Task CreateEventAsync(Event newEvent)
        {
            var response = await _httpClient.PostAsJsonAsync("api/events", newEvent);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/events/{updatedEvent.Id}", updatedEvent);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEventAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/events/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}