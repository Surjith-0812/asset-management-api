using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Repositories
{
    public interface IAssetRepository
    {
        Task<Asset> AddAsync(Asset asset);

        Task<IEnumerable<Asset>> GetAllAsync();

        Task<Asset?> GetByIdAsync(Guid id);

        Task<Asset?> DeleteAsset(Guid id);

    }
}
