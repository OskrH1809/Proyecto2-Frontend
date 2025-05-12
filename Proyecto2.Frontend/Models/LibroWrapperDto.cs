namespace Proyecto2.Frontend.Models;

public class LibroWrapperDto
{
    public int Id { get; set; }
    public LibroDto Libro { get; set; } = new();
}
