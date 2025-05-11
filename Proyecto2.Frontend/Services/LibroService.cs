using Proyecto2.Frontend.Models;
using System.Net.Http.Json;

namespace Proyecto2.Frontend.Services;

public class LibroService : ILibroService
{
    private readonly HttpClient _http;

    public LibroService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<LibroDto>> BuscarAsync(string query)
    {
        var response = await _http.GetFromJsonAsync<List<LibroDto>>($"api/libros/search?query={query}");
        return response ?? new List<LibroDto>();
    }

    public async Task<bool> CrearAsync(LibroDto libro)
    {
        var response = await _http.PostAsJsonAsync("api/libros", libro);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<LibroDto>> ObtenerTodosAsync()
    {
        var libros = await _http.GetFromJsonAsync<List<LibroDto>>("api/libros");
        return libros ?? new();
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/libros/{id}");
        return response.IsSuccessStatusCode;
    }

}
