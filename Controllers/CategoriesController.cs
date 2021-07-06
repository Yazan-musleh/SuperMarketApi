using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Model;
using Supermarket.API.Domain.Model.Services;
using Supermarket.API.Domain.Services;
using Supermarket.API.DTOs;
using Supermarket.API.Extensions;

namespace Supermarket.API.Controllers
{

    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
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

            var result = await _categoryService.SaveAsync(category); 

            if (!result.Success)
            {
                return BadRequest(result.Message);;
            }

            var categoryResource = _mapper.Map<Category, CategoryDto>(result.Category);

            return Ok(categoryResource);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreateCategory resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<CreateCategory, Category>(resource);

            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryRes = _mapper.Map<Category, CategoryDto>(result.Category);

            return Ok(categoryRes);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Category, CategoryDto>(result.Category);

            return Ok(categoryResource);
        }

    }
}