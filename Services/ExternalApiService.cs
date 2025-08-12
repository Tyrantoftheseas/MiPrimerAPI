// Services/ExternalApiService.cs - CORRECTO
using System.Text.Json;

public class ExternalApiService
{
    private readonly HttpClient _httpClient;

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Services/ExternalApiService.cs
    public async Task<string> GetUsersAsync()
    {
        try
        {
            // Cambia a JSONPlaceholder que es más estable
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }
        catch (Exception ex)
        {
            return $"Error de conexión: {ex.Message}";
        }
    }

    // Método adicional con tipado fuerte
    public async Task<List<User>> GetUsersTypedAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("https://reqres.in/api/users?page=1");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var userResponse = JsonSerializer.Deserialize<UserResponse>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return userResponse?.Data ?? new List<User>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<User>();
        }
    }
}