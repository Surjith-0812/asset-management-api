using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories
{
    public class AssetRepository : IAssetRepository
    {

        private readonly ApplicationDbContext _context;

        public AssetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Asset> AddAsync(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
            await _context.SaveChangesAsync();
            return asset;
        }

        public async Task<Asset?> DeleteAsset(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);

            if (asset == null)
                return null;

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();

            return asset;
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
           return await _context.Assets.ToListAsync();
        }

        public async Task<Asset?> GetByIdAsync(Guid id)
        {
            return await _context.Assets.FirstOrDefaultAsync(ast => ast.Id == id);

        }
    }
}
