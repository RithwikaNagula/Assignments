using System.ComponentModel.DataAnnotations;

namespace JWTRoles.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public string? Position { get; set; }
        public decimal Salary { get; set; }

    }

}
