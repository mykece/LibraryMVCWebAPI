using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Application.Services.CategoryServices;
using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Domain.Utilities.Concretes;
using HS_14_MVC.UI.Areas.Admin.Models.CategoryVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HS_14_MVC.UI.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllAsync();
            if (!result.IsSuccess)
            {
                notyfService.Error(result.Messages);
            }

            var CategoryListVMs = result.Data.Adapt<List<AdminCategoryListVM>>();
            notyfService.Success(result.Messages);
            return View(CategoryListVMs);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminCategoryCreateVM model)
        {
            var categoryDTO = model.Adapt<CategoryCreateDTO>();
            var result = await _categoryService.CreateAsync(categoryDTO);
            if (!result.IsSuccess)
            {
                notyfService.Error(result.Messages);
                return View(model);
            }
            notyfService.Success(result.Messages);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                notyfService.Error(result.Messages);
                return RedirectToAction("Index");
            }
            notyfService.Success(result.Messages);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            var categoryUpdateVm = result.Data.Adapt<AdminCategoryUpdateVM>();
            return View(categoryUpdateVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminCategoryUpdateVM model)
        {
            var result = await _categoryService.UpdateAsync(model.Adapt<CategoryUpdateDTO>());
            if (!result.IsSuccess)
            {
                notyfService.Error(result.Messages);
                return View(model);
            }
            notyfService.Success(result.Messages);

            return RedirectToAction("Index");
        }
    }
}
