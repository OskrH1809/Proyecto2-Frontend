using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto2.Shared.Models;

namespace Proyecto2.Shared.Contracts
{
    public interface IAutorService
    {
        Task<bool> CrearAsync(AutorDto autor);
        Task<List<AutorDto>> ObtenerTodosAsync();
        Task<bool> EliminarAsync(int id);

        Task<AutorDto?> ObtenerPorIdAsync(int id);
        Task<bool> ActualizarAsync(int id, AutorDto autor);
    }
}
