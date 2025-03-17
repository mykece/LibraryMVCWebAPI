﻿using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Application.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_14_MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
        {
            var result = await _categoryService.CreateAsync(categoryCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(CategoryUpdateDTO categoryUpdateDTO)
        {
            var result = await _categoryService.UpdateAsync(categoryUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
    }
}
