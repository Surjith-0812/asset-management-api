using AssetManagement.Application.Interfaces.DTOs;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public async Task<ActionResult<AssetDto>> GetAllAssets()
        {
            var results = await _assetService.GetAssetsAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDto>> GetAsset(Guid id)
        {
            var results = await _assetService.GetAssetByIdAsync(id);
            if (results is null)
                return NotFound();
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<AssetDto>> AddAsset(CreateAssetDto addDto)
        {
            var asset = await _assetService.CreateAssetAsync(addDto);
            return CreatedAtAction("GetAsset", new { id = asset.Id }, asset);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssetDto>> DeleteAsset(Guid id)
        {
            var asset = await _assetService.DeleteAsset(id);
            if (asset == null) return NotFound();
            return Ok(asset);

        }
    }
}
