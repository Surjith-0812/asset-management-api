using AssetManagement.Application.Interfaces.DTOs;
using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _automapper;

        public AssetService(IAssetRepository assetRepository, IMapper automapper)
        {
            _assetRepository = assetRepository;
            _automapper = automapper;
        }

        public async Task<AssetDto> CreateAssetAsync(CreateAssetDto assertDto)
        {
            var asset = _automapper.Map<Asset>(assertDto);
            asset.Id = Guid.NewGuid();
            var addAsset = await _assetRepository.AddAsync(asset);
            return _automapper.Map<AssetDto>(addAsset);
        }

        public async Task<AssetDto?> DeleteAsset(Guid id)
        {
            var deleteResult = await _assetRepository.DeleteAsset(id);
            if (deleteResult != null) { return null; }

            return _automapper.Map<AssetDto>(deleteResult);
        }

        public async Task<AssetDto?> GetAssetByIdAsync(Guid assetId)
        {
            var asset = await _assetRepository.GetByIdAsync(assetId);

            if (asset == null)
                return null;

            return _automapper.Map<AssetDto>(asset);
        }

        public async Task<IEnumerable<AssetDto>> GetAssetsAsync()
        {
            var asset = await _assetRepository.GetAllAsync();
            return _automapper.Map<IEnumerable<AssetDto>>(asset);
        }

    }
}
