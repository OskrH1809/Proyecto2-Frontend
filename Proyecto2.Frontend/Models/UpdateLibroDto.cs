namespace Proyecto2.Frontend.Models;

public class UpdateLibroDto
{
    public int Id { get; set; }
    public SendLibro Libro { get; set; } = new();
}
