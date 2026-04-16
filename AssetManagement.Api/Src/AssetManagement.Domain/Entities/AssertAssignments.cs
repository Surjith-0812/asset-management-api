using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class AssetAssignment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AssetId { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime AssignedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public required Asset Asset { get; set; }

        public required Employee Employee { get; set; }
    }
}
