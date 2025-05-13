using Proyecto2.Shared.DTOs;

namespace Proyecto2.Shared.Contracts;

public interface IAutorService
{
    Task<List<AutorDto>> ObtenerTodosAsync();
    Task<AutorDto?> ObtenerPorIdAsync(int id);
    Task<AutorDto> CrearAsync(AutorDto autor);
    Task<AutorDto> ActualizarAsync(int id, AutorDto autor);
    Task<bool> EliminarAsync(int id);
}
