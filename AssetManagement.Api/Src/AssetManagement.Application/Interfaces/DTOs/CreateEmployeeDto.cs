using AssetManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Interfaces.DTOs
{
    public class CreateEmployeeDto
    {
        public Guid Id { get; set; }

        public required string EmployeeCode { get; set; }

        public required string Name { get; set; }

        public required Branch Branch { get; set; }

        public string? Email { get; set; }

        public string? Department { get; set; }

        public string? PhoneNumber { get; set; }
       
        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
