using AssetManagement.Application.Interfaces.DTOs;
using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeService, IMapper automapper)
        {
            _employeeRepository = employeeService;
            _mapper = automapper;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto employee)
        {
            var emp = _mapper.Map<Employee>(employee);
            emp.Id = Guid.NewGuid();
            var result = await _employeeRepository.AddAsync(emp);
            return _mapper.Map<EmployeeDto>(result);
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id)
        {
            var getResult = await _employeeRepository.GetByIdAsync(id);
            if (getResult is null)
                return null;
            return _mapper.Map<EmployeeDto>(getResult);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> RemoveEmployee(Guid id)
        {
            var delResult = await _employeeRepository.RemoveEmployee(id);
            if (delResult is null) return null;

            return _mapper.Map<EmployeeDto?>(delResult);
        }
    }
}
