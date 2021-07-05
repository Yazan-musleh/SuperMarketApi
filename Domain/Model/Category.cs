using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Domain.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}