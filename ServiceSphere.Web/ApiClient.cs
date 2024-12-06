/*using ServiceSphere.Domain.Entities;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Método para obtener eventos desde la API 
    public async Task<IEnumerable<Event>> GetEvents()
    {
        var response = await _httpClient.GetAsync("/api/events");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<IEnumerable<Event>>();
    }

    // Métodos adicionales para otras entidades...
}*/