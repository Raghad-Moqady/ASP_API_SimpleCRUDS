using System.ComponentModel.DataAnnotations;

namespace App1.DTOs.categories
{
    public class CreateDTO
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
    }
}
