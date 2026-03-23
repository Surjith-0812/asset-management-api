using AssetManagement.Application.Interfaces.DTOs;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Application.Services;
using AssetManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> AddEmployee(CreateEmployeeDto employee)
        {
            var addResult = await _employeeService.CreateEmployeeAsync(employee);
            return CreatedAtAction("GetEmployee", new { employeeId = addResult.Id }, addResult);
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(Guid employeeId)
        {
            var addResult = await _employeeService.GetEmployeeByIdAsync(employeeId);
            if (addResult is null) return NotFound();
            return Ok(addResult);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var result = await _employeeService.GetEmployeesAsync();
            if (!result.Any())
                return NoContent();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDto>> RemoveEmployee(Guid id)
        {
            var employee = await _employeeService.RemoveEmployee(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }
    }
}
