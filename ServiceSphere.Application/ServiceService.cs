using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;

namespace ServiceSphere.Application.Services
{
    public class ServiceService
    {
        private readonly HttpClient _httpClient;

        public ServiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Service>>("api/services");
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Service>($"api/services/{id}");
        }

        public async Task CreateServiceAsync(Service newService)
        {
            var response = await _httpClient.PostAsJsonAsync("api/services", newService);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateServiceAsync(Service updatedService)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/services/{updatedService.ServiceId}", updatedService);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/services/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}