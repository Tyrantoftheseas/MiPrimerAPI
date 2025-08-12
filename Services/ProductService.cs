// Services/ProductService.cs
using MiPrimerAPI.Models;
using MiPrimerAPI.Repositories;

namespace MiPrimerAPI.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID debe ser mayor a 0");

            return await _repository.GetByIdAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("El nombre del producto es requerido");

            if (product.Price <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");

            return await _repository.AddAsync(product);
        }

        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            if (id <= 0)
                throw new ArgumentException("ID debe ser mayor a 0");

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("El nombre del producto es requerido");

            if (product.Price <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");

            return await _repository.UpdateAsync(id, product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID debe ser mayor a 0");

            return await _repository.DeleteAsync(id);
        }
    }
}