using AssetManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddAsync(Employee employee);

        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(Guid id);

        Task<Employee?> RemoveEmployee(Guid id);
    }
}
