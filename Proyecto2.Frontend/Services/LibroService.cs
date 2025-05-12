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
        var response = await _http.GetFromJsonAsync<List<LibroWrapperDto>>($"api/libros/search?query={query}");
        return response?.Select(r => r.Libro).ToList() ?? new List<LibroDto>();
    }


    public async Task<bool> CrearAsync(LibroDto libro)
    {
        var wrapper = new LibroWrapperDto { Id = libro.Id, Libro = libro };
        var response = await _http.PostAsJsonAsync("api/libros", wrapper);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ActualizarAsync(int id, LibroDto libro)
    {
        var wrapper = new LibroWrapperDto { Id = id, Libro = libro };
        var response = await _http.PutAsJsonAsync($"api/libros/{id}", wrapper);
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

    public async Task<LibroDto?> ObtenerPorIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<LibroDto>($"api/libros/{id}");
    }

   


}
