namespace Proyecto2.Frontend.Models;

public class AutorDto
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = "";
    public DateTime? FechaNacimiento { get; set; }
    public string Ciudad { get; set; } = "";
    public string Correo { get; set; } = "";
}
