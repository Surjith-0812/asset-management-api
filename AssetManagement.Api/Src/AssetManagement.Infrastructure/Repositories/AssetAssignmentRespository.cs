using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories
{
    public class AssetAssignmentRespository : IAssetAssignmentRespository
    {
        private readonly ApplicationDbContext _context;

        public AssetAssignmentRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AssignAssetAsync(AssetAssignment asset)
        {
            await _context.AssetAssignments.AddAsync(asset);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AssetAssignment>> GetAllAssignmentsAsync()
        {
            return await _context.AssetAssignments.AsNoTracking().Include(a => a.Asset).Include(e => e.Employee).ToListAsync();
        }

        public async Task<AssetAssignment?> GetAssignmentByIdAsync(Guid id)
        {
            return await _context.AssetAssignments.AsNoTracking().Include(a => a.Asset).Include(e => e.Employee).FirstOrDefaultAsync(asset => asset.Id == id);
        }

        public async Task<IEnumerable<AssetAssignment>> GetAssignmentsByAssetIdAsync(Guid assetId)
        {
            return await _context.AssetAssignments.AsNoTracking().Include(a => a.Asset).Include(eid => eid.Employee).Where(aa => aa.AssetId == assetId).ToListAsync();
        }

        public async Task<IEnumerable<AssetAssignment>> GetAssignmentsByEmployeeIdAsync(Guid employeeId)
        {
            return await _context.AssetAssignments.AsNoTracking().Include(a => a.Asset).Include(e => e.Employee).Where(a => a.EmployeeId == employeeId).ToListAsync();

        }

        public async Task<AssetAssignment> ReturnAssetAsync(Guid assignmentId)
        {
            var assignment = await _context.AssetAssignments.FirstOrDefaultAsync(a => a.Id == assignmentId) ?? throw new KeyNotFoundException("Assignment not found");

            if (assignment.ReturnedDate != null)
                throw new Exception("Asset already returned");
            // mark as returned
            assignment.ReturnedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return await _context.AssetAssignments.AsNoTracking().Include(a => a.Asset).Include(e => e.Employee).FirstAsync(a => a.Id == assignmentId);
        }
    }
}
