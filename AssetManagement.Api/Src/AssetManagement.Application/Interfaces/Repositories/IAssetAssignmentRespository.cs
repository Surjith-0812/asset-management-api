using AssetManagement.Application.Interfaces.DTOs;
using AssetManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Interfaces.Repositories
{
    public interface IAssetAssignmentRespository
    {
        Task AssignAssetAsync(AssetAssignment asset);

        Task<AssetAssignment> ReturnAssetAsync(Guid assignmentId);

        Task<IEnumerable<AssetAssignment>> GetAllAssignmentsAsync();

        Task<AssetAssignment?> GetAssignmentByIdAsync(Guid id);

        Task<IEnumerable<AssetAssignment>> GetAssignmentsByEmployeeIdAsync(Guid employeeId);

        Task<IEnumerable<AssetAssignment>> GetAssignmentsByAssetIdAsync(Guid assetId);
    }
}
