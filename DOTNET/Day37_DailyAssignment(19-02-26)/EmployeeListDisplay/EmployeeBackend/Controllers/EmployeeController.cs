using EmployeeBackend.Data;
using EmployeeBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
            private readonly EmployeeDbContext context;

            public EmployeeController(EmployeeDbContext context)
            {
                this.context = context;
            }

            // GET: api/employee
            [HttpGet]
            public async Task<IActionResult> GetEmployees()
            {
                var employees = await context.Employees.ToListAsync();
                return Ok(employees);
            }

            // POST: api/employee
            [HttpPost]
            public async Task<IActionResult> AddEmployee(Employee employee)
            {
                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();
                return Ok(employee);
            }
        }
    }

