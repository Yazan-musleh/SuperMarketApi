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

    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryService, IMapper mapper)
        {
            this._mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();

            return  _mapper
            .Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCategory resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<CreateCategory, Category>(resource);
        }

    }
}