using Proyecto2.Frontend.Models;

namespace Proyecto2.Frontend.Services;

public interface ILibroService
{
    Task<List<LibroDto>> BuscarAsync(string query);
    Task<bool> CrearAsync(LibroDto libro);
    Task<List<LibroDto>> ObtenerTodosAsync();
    Task<bool> EliminarAsync(int id);
    Task<LibroDto?> ObtenerPorIdAsync(int id);
    Task<bool> ActualizarAsync(int id, LibroDto libro);


}
