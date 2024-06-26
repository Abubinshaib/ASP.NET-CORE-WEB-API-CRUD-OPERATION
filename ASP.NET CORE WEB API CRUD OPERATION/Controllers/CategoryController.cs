﻿using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Contracts;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Data.Models;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.DTOs.Category;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);

            await this._categoryRepository.CreateAsync(category);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }


        // GET: api/GetCategory/1
        [HttpGet("GetCategory")]
        public async Task<ActionResult<GetCategoryDetailsDto>> GetCategory(int categoryId)
        {
            var category = await this._categoryRepository.GetAsync(categoryId);

            if (category == null)
            {
                throw new Exception($"CategoryID {categoryId} is not found.");
            }

            var categoryDetailsDto = _mapper.Map<GetCategoryDetailsDto>(category);

            return Ok(categoryDetailsDto);
        }


        [HttpGet("GetAllCategories")]

        public async Task<ActionResult<List<GetCategoryProductsDto>>> GetAllCategories()
        {
            var categories = await this._categoryRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCategoryProductsDto>>(categories);
            return Ok(records);
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto)
        {
            if (categoryId != updateCategoryDto.Id)
            {
                return BadRequest("Invalid Category Id");
            }

            var category = await _categoryRepository.GetAsync(categoryId);

            if (category == null)
            {
                throw new Exception($"CategoryID {categoryId} is not found.");
            }

            _mapper.Map(updateCategoryDto, category);

            try
            {
                await _categoryRepository.UpdateAsync(category);
            }
            catch (Exception)
            {
                throw new Exception($"Error occured while updating CategoryID {categoryId}.");
            }

            return NoContent();
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _categoryRepository.DeleteAsync(categoryId);
            return NoContent();
        }
    }
}

