using Proyecto2.Frontend.Models;
using System.Net.Http.Json;

namespace Proyecto2.Frontend.Services;

public class AutorService : IAutorService
{
    private readonly HttpClient _http;

    public AutorService(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> CrearAsync(AutorDto autor)
    {
        var response = await _http.PostAsJsonAsync("api/autores", autor);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<AutorDto>> ObtenerTodosAsync()
    {
        var autores = await _http.GetFromJsonAsync<List<AutorDto>>("api/autores");
        return autores ?? new();
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/autores/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<AutorDto?> ObtenerPorIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<AutorDto>($"api/autores/{id}");
    }

    public async Task<bool> ActualizarAsync(int id, AutorDto autor)
    {
        var wrapper = new AutorWrapperDto
        {
            Id = id,
            Autor = autor  // Ya no uses AutorSinIdDto
        };

        var response = await _http.PutAsJsonAsync($"api/autores/{id}", wrapper);
        return response.IsSuccessStatusCode;
    }







}
