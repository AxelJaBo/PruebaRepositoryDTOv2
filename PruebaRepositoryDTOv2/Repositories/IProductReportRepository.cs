using PruebaRepositoryDTOv2.DTOs;

namespace PruebaRepositoryDTOv2.Repositories
{
    public interface IProductReportRepository
    {
        Task<IEnumerable<ProductReportDTO>> GetProductReportAsync();
    }
}
