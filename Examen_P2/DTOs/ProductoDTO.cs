namespace Examen_P2.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<string> Categorias { get; set; } = new();
    }
}
