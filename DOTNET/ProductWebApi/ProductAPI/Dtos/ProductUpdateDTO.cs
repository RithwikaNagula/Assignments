using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Dtos
{
    public class ProductUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
