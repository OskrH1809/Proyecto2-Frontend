using Proyecto2.Frontend.Models;

namespace Proyecto2.Frontend.Services;

public interface IAutorService
{
    Task<bool> CrearAsync(AutorDto autor);
    Task<List<AutorDto>> ObtenerTodosAsync();
    Task<bool> EliminarAsync(int id);

    Task<AutorDto?> ObtenerPorIdAsync(int id);
    Task<bool> ActualizarAsync(int id, AutorDto autor);
}
