using System;

namespace Proyecto2.Shared.DTOs
{
    public class AutorDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
    }
}
