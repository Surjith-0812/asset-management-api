using AssetManagement.Application.Interfaces.DTOs;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetAssignmentController : ControllerBase
    {
        private readonly IAssetAssignmentService _service;

        public AssetAssignmentController(IAssetAssignmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetAssignmentDto>>> GetAllAssignmentsAsync()
        {
            var result = await _service.GetAllAssignmentsAsync();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetAssignmentById")]
        public async Task<ActionResult<AssetAssignmentDto>> GetAssignmentByIdAsync(Guid id)
        {
            var result = await _service.GetAssignmentByIdAsync(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AssetAssignmentDto>> AssignAssetAsync(CreateAssetAssignmentDto dto)
        {
            var result = await _service.AssignAssetAsync(dto);
            return CreatedAtAction("GetAssignmentById", new { id = result.Id }, result);
        }
       
        [HttpPost("{id}/return")]
        public async Task<ActionResult<AssetAssignmentDto>> ReturnAssetAsync(Guid id)
        {
            var result = await _service.ReturnAssetAsync(id);
            return CreatedAtAction("GetAssignmentById", new { id = result.Id }, result);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<AssetAssignmentDto>>> GetAssignmentsByEmployeeIdAsync(Guid employeeId)
        {
            var result = await _service.GetAssignmentsByEmployeeIdAsync(employeeId);
            return Ok(result);
        }

        [HttpGet("asset/{assetId}")]
        public async Task<ActionResult<IEnumerable<AssetAssignmentDto>>> GetAssignmentsByAssetIdAsync(Guid assetId)
        {
            var result = await _service.GetAssignmentsByAssetIdAsync(assetId);
            return Ok(result);
        }

    }
}
