using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CountryStateCity.Models
{
    [Table("States")]
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        [MaxLength(100)]
        public string StateName { get; set; }
        // Foreign Key
        public int CountryId { get; set; } 
        // Navigation Properties
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
