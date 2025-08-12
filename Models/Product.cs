namespace MiPrimerAPI.Models
{
    public class Product
    {
        public int Id { get; set; }               // Identificador único
        public string Name { get; set; } = string.Empty;  // Nombre del producto
        public decimal Price { get; set; }        // Precio del producto
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Fecha de creación
    }
}
