using HS_14_MVC.Application.DTOs.AuthorDTOs;
using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Application.Services.AuthorServices;
using HS_14_MVC.UI.Areas.Admin.Models.AuthorVMs;
using HS_14_MVC.UI.Areas.Admin.Models.CategoryVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HS_14_MVC.UI.Areas.Admin.Controllers
{
    public class AuthorController : AdminBaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _authorService.GetAllAsync();
            if (!result.IsSuccess)
            {
                notyfService.Error(result.Messages);
                return View();
            }

            var CategoryListVMs = result.Data.Adapt<List<AdminAuthorListVM>>();
            notyfService.Success(result.Messages);
            return View(CategoryListVMs);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminAuthorCreateVM model)
        {
            var authorDTO = model.Adapt<AuthorCreateDTO>();
            var result = await _authorService.CreateAsync(authorDTO);
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
            var result = await _authorService.DeleteAsync(id);
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
            var result = await _authorService.GetByIdAsync(id);
            var authorUpdateVm = result.Data.Adapt<AdminAuthorUpdateVM>();
            return View(authorUpdateVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminAuthorUpdateVM model)
        {
            var result = await _authorService.UpdateAsync(model.Adapt<AuthorUpdateDTO>());
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
