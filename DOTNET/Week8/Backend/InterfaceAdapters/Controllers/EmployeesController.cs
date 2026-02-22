using System.Security.Claims;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceAdapters.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET /api/Employees
        // Admin → all employees
        // Manager → only subordinates (ManagerId = their employee Id)
        // Employee → only own profile
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> GetAll()
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;

            if (string.IsNullOrEmpty(role))
                return Unauthorized(new { message = "Could not identify user role" });

            if (role == "Admin")
            {
                // Admin sees everyone — doesn't need userId
                var employees = await _employeeService.GetAllAsync();
                return Ok(employees);
            }

            // Manager and Employee need userId
            if (string.IsNullOrEmpty(userIdStr))
                return Unauthorized(new { message = "Please log out and log back in to refresh your session." });

            var userId = int.Parse(userIdStr);

            if (role == "Manager")
            {
                // Manager sees only their subordinates
                var myProfile = await _employeeService.GetByUserIdAsync(userId);
                if (myProfile == null)
                    return NotFound(new { message = "Manager profile not found" });

                var subordinates = await _employeeService.GetByManagerIdAsync(myProfile.Id);
                return Ok(subordinates);
            }
            else
            {
                // Employee sees only own profile
                var myProfile = await _employeeService.GetByUserIdAsync(userId);
                if (myProfile == null)
                    return NotFound(new { message = "Employee profile not found" });

                return Ok(new[] { myProfile });
            }
        }

        // GET /api/Employees/me — returns the logged-in user's own profile
        [HttpGet("me")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> GetMe()
        {
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
            if (string.IsNullOrEmpty(userIdStr))
                return Unauthorized(new { message = "Could not identify user" });

            var userId = int.Parse(userIdStr);
            var myProfile = await _employeeService.GetByUserIdAsync(userId);

            if (myProfile == null)
                return NotFound(new { message = "Employee profile not found for this user" });

            return Ok(myProfile);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound(new { message = "Employee not found" });

            return Ok(employee);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            var employee = await _employeeService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto dto)
        {
            var employee = await _employeeService.UpdateAsync(id, dto);
            if (employee == null)
                return NotFound(new { message = "Employee not found" });

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteAsync(id);
            if (!result)
                return NotFound(new { message = "Employee not found" });

            return Ok(new { message = "Employee deleted successfully" });
        }
    }
}
