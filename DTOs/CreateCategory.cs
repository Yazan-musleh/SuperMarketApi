using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.DTOs
{
    public class CreateCategory
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}