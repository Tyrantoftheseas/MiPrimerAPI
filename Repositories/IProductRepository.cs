// Repositories/IProductRepository.cs
using MiPrimerAPI.Models;

namespace MiPrimerAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();        // Obtener todos los productos
        Task<Product?> GetByIdAsync(int id);             // Obtener producto por ID
        Task<Product> AddAsync(Product product);         // Agregar nuevo producto
        Task<Product?> UpdateAsync(int id, Product product); // Actualizar producto
        Task<bool> DeleteAsync(int id);                  // Eliminar producto
    }
}
