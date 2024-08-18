using PruebaRepositoryDTOv2.DTOs;

namespace PruebaRepositoryDTOv2.Repositories
{
    public interface IProviderRepository
    {
        Task<IEnumerable<ProviderDTO>> GetProvidersAsync();
    }
}
