using AssetManagement.Domain.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class Asset
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string SerialNumber { get; set; }

        public AssertType AssertType { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public DateTime PurchaseData { get; set; }

        public DateTime? WarrantyExpiryDate { get; set; }

        public string? Location { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public AssertStatus AssertStatus { get; set; }

        public string? Notes { get; set; }

        public ICollection<AssetAssignment> Assignments { get; set; } = [];
    }
}
