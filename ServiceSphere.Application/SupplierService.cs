using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;

namespace ServiceSphere.Application.Services
{
    public class SupplierService
    {
        private readonly HttpClient _httpClient;

        public SupplierService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Supplier>> GetSuppliersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Supplier>>("api/suppliers");
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Supplier>($"api/suppliers/{id}");
        }

        public async Task CreateSupplierAsync(Supplier supplier)
        {
            var response = await _httpClient.PostAsJsonAsync("api/suppliers", supplier);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/suppliers/{supplier.Id}", supplier);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/suppliers/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
