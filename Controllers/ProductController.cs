using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Model;
using Supermarket.API.Domain.Model.Services;
using Supermarket.API.DTOs;
using Supermarket.API.Extensions;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> ListAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProduct createProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var product = _mapper.Map<CreateProduct, Product>(createProduct);
            var result = await _productService.AddProduct(product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Product, ProductDto>(result.Data);

            return Ok(categoryResource);
        }
        
    }
}