using AssetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Persistence
{
    public  class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
        public DbSet<Asset> Assets { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<AssetAssignment> AssetAssignments { get; set; }
    }
}
