using System.ComponentModel.DataAnnotations;

namespace App1.DTOs.products
{
    public class UpdateProductDTO
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
