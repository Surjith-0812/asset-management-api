using AssetManagement.Application.Interfaces.DTOs;
using AssetManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Interfaces.Services
{
    public interface IAssetService
    {
        Task<AssetDto> CreateAssetAsync(CreateAssetDto assertDto);

        Task<IEnumerable<AssetDto>> GetAssetsAsync();

        Task<AssetDto?> GetAssetByIdAsync(Guid assetId);

        Task<AssetDto?> DeleteAsset(Guid id);
    }
}
