using AssetManagement.Application.Interfaces.DTOs;
using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Services
{
    public class AssetAssignmentService : IAssetAssignmentService
    {
        private IAssetAssignmentRespository _assignmentRepos;
        private IAssetRepository _assetRepos;
        private IEmployeeRepository _employeeRepos;
        private IMapper _mapper;

        public AssetAssignmentService(IAssetAssignmentRespository repos, IAssetRepository assetRepos, IEmployeeRepository employeeRepos, IMapper mapper)
        {
            _assignmentRepos = repos;
            _mapper = mapper;
            _employeeRepos = employeeRepos;
            _assetRepos = assetRepos;
        }

        public async Task<AssetAssignmentDto> AssignAssetAsync(CreateAssetAssignmentDto dto)
        {
            var asset = await _assetRepos.GetByIdAsync(dto.AssetId) ?? throw new Exception("Invalid asset");

            var employee = await _employeeRepos.GetByIdAsync(dto.EmployeeId) ?? throw new Exception("Invalid employee");

            var existingAssignments = await _assignmentRepos.GetAssignmentsByAssetIdAsync(dto.AssetId);

            if (existingAssignments.Any(a => a.ReturnedDate == null))
                throw new InvalidOperationException("Asset is already assigned");

            var assignment = _mapper.Map<AssetAssignment>(dto);
            assignment.AssignedDate = DateTime.UtcNow;

            await _assignmentRepos.AssignAssetAsync(assignment);

            return _mapper.Map<AssetAssignmentDto>(assignment);
        }

        public async Task<IEnumerable<AssetAssignmentDto>> GetAllAssignmentsAsync()
        {
            return _mapper.Map<IEnumerable<AssetAssignmentDto>>(await _assignmentRepos.GetAllAssignmentsAsync());

        }

        public async Task<AssetAssignmentDto?> GetAssignmentByIdAsync(Guid id)
        {
            var result = await _assignmentRepos.GetAssignmentByIdAsync(id);

            if (result == null)
                return null;

            return _mapper.Map<AssetAssignmentDto?>(result);
        }

        public async Task<IEnumerable<AssetAssignmentDto>> GetAssignmentsByAssetIdAsync(Guid assetId)
        {
            var result = await _assignmentRepos.GetAssignmentsByAssetIdAsync(assetId);

            return _mapper.Map<IEnumerable<AssetAssignmentDto>>(result);
        }

        public async Task<IEnumerable<AssetAssignmentDto>> GetAssignmentsByEmployeeIdAsync(Guid employeeId)
        {
            var result = await _assignmentRepos.GetAssignmentsByEmployeeIdAsync(employeeId);

            return _mapper.Map<IEnumerable<AssetAssignmentDto>>(result);
        }

        public async Task<AssetAssignmentDto> ReturnAssetAsync(Guid assignmentId)
        {
            var assignment = await _assignmentRepos.GetAssignmentByIdAsync(assignmentId) ?? throw new Exception("Invalid assignment");
            assignment =  await _assignmentRepos.ReturnAssetAsync(assignment.Id);
            return _mapper.Map<AssetAssignmentDto>(assignment);
        }
    }
}
