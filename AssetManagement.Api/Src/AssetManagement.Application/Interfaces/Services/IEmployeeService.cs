using AssetManagement.Application.Interfaces.DTOs;
using AssetManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto employee);

        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();

        Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id);

        Task<EmployeeDto?> RemoveEmployee(Guid id);
    }
}
