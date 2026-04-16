using AssetManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Interfaces.DTOs
{
    public class AssetAssignmentDto
    {
        public Guid Id { get; set; }

        public Guid AssetId { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime? AssignedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public string? AssetName { get; set; }

        public string? EmployeeName { get; set; }
    }
}
