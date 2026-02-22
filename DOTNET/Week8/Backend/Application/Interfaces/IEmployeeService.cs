using Application.DTOs;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<EmployeeDto?> GetByEmailAsync(string email);
        Task<EmployeeDto?> GetByUserIdAsync(int userId);
        Task<IEnumerable<EmployeeDto>> GetByManagerIdAsync(int managerId);
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto);
        Task<EmployeeDto?> UpdateAsync(int id, UpdateEmployeeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
