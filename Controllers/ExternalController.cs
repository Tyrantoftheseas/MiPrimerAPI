// Controllers/ExternalController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ExternalController : ControllerBase
{
    private readonly ExternalApiService _apiService;

    public ExternalController(ExternalApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var result = await _apiService.GetUsersAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }

    [HttpGet("users-typed")]
    public async Task<IActionResult> GetUsersTyped()
    {
        try
        {
            var users = await _apiService.GetUsersTypedAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }
}