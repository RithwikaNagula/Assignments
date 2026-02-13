using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Dtos
{
    public class ProductCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(1, 100000)]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
