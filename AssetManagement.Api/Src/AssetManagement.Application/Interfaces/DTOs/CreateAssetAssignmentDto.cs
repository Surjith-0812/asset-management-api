using AssetManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Interfaces.DTOs
{
    public class CreateAssetAssignmentDto
    {
        public Guid AssetId { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
