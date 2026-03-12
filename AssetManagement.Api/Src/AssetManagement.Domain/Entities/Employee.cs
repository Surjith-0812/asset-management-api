namespace AssetManagement.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public required string EmployeeCode { get; set; }

        public required string Name { get; set; }

        public string? Email { get; set; }

        public string? Department { get; set; }

        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; }

        public ICollection<AssetAssignment> AssetAssignments { get; set; } = [];
    }
}