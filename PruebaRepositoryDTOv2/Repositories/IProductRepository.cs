using PruebaRepositoryDTOv2.DTOs;

namespace PruebaRepositoryDTOv2.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task AddProductAsync(ProductDTO productDTO);
    }
}
