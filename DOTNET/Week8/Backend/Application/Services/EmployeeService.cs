using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return employees.Select(e => MapToDto(e));
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return employee == null ? null : MapToDto(employee);
        }

        public async Task<EmployeeDto?> GetByEmailAsync(string email)
        {
            var employee = await _repository.GetByEmailAsync(email);
            return employee == null ? null : MapToDto(employee);
        }

        public async Task<EmployeeDto?> GetByUserIdAsync(int userId)
        {
            var employee = await _repository.GetByUserIdAsync(userId);
            return employee == null ? null : MapToDto(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetByManagerIdAsync(int managerId)
        {
            var employees = await _repository.GetByManagerIdAsync(managerId);
            return employees.Select(e => MapToDto(e));
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                Department = dto.Department,
                Salary = dto.Salary,
                Role = dto.Role,
                ManagerId = dto.ManagerId
            };

            var created = await _repository.AddAsync(employee);
            return MapToDto(created);
        }

        public async Task<EmployeeDto?> UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return null;

            employee.Name = dto.Name;
            employee.Email = dto.Email;
            employee.Department = dto.Department;
            employee.Salary = dto.Salary;
            employee.Role = dto.Role;
            employee.ManagerId = dto.ManagerId;

            var updated = await _repository.UpdateAsync(employee);
            return updated == null ? null : MapToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private static EmployeeDto MapToDto(Employee e)
        {
            return new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Department = e.Department,
                Salary = e.Salary,
                Role = e.Role,
                ManagerId = e.ManagerId,
                ManagerName = e.Manager?.Name
            };
        }
    }
}
