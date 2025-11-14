using System.ComponentModel.DataAnnotations;

namespace App1.DTOs.categories
{
    public class UpdateDto
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

    }
}
