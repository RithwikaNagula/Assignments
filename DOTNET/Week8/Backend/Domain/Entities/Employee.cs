namespace Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Role { get; set; } = "Employee"; // Admin / Manager / Employee

        // FK to Users table — links authentication to business data
        public int? UserId { get; set; }

        // Self-referencing relationship: Manager is also an Employee
        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }
        public List<Employee> Subordinates { get; set; } = new();
    }
}
