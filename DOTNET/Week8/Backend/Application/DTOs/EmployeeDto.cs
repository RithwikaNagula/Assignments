namespace Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Role { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }
    }

    public class CreateEmployeeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Role { get; set; } = "Employee";
        public int? ManagerId { get; set; }
    }

    public class UpdateEmployeeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Role { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
    }
}
