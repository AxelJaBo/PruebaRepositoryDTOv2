using PruebaRepositoryDTOv2.DTOs;

namespace PruebaRepositoryDTOv2.Repositories
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductTypeDTO>> GetProductTypesAsync();
    }
}
