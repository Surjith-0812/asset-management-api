using AssetManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Interfaces.DTOs
{
    public class AssetDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string SerialNumber { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }
    }
}
