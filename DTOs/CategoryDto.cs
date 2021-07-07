using System.Collections.Generic;
using Supermarket.API.Domain.Model;

namespace Supermarket.API.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}