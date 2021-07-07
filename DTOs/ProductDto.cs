using Supermarket.API.Domain.Model.Services.Communication;

namespace Supermarket.API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public Response Category { get; set; }
    }
}