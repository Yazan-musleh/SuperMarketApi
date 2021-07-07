using System.ComponentModel.DataAnnotations;
using Supermarket.API.Domain.Model;

namespace Supermarket.API.DTOs
{
    public class CreateProduct
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public short QuantityInPackage { get; set; }
        [Required]
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        public int CategoryId { get; set; }
        
    }
}