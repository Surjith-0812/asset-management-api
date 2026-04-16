using AssetManagement.Application.Interfaces.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Interfaces.Services
{
    public interface IAssetAssignmentService
    {
        Task<AssetAssignmentDto> AssignAssetAsync(CreateAssetAssignmentDto dto);

        Task<AssetAssignmentDto> ReturnAssetAsync(Guid assignmentId);

        Task<IEnumerable<AssetAssignmentDto>> GetAllAssignmentsAsync();

        Task<AssetAssignmentDto?> GetAssignmentByIdAsync(Guid id);

        Task<IEnumerable<AssetAssignmentDto>> GetAssignmentsByEmployeeIdAsync(Guid employeeId);

        Task<IEnumerable<AssetAssignmentDto>> GetAssignmentsByAssetIdAsync(Guid assetId);
    }
}
