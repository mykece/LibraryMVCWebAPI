using HS_14_MVC.Application.DTOs.AuthorDTOs;
using HS_14_MVC.Application.DTOs.BookDTOs;
using HS_14_MVC.Application.Services.AuthorServices;
using HS_14_MVC.Application.Services.BookServices;
using HS_14_MVC.Application.Services.CategoryServices;
using HS_14_MVC.Application.Services.PublisherServices;
using HS_14_MVC.Domain.Entities;
using HS_14_MVC.UI.Areas.Admin.Models.AuthorVMs;
using HS_14_MVC.UI.Areas.Admin.Models.BookVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HS_14_MVC.UI.Areas.Admin.Controllers
{
    public class BookController : AdminBaseController
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public BookController(IBookService bookService, ICategoryService categoryService, IAuthorService authorService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bookService.GetAllAsync();
            if (!result.IsSuccess)
            {
                notyfService.Error(result.Messages);
                return View();
            }

            var BookListVMs = result.Data.Adapt<List<AdminBookListVM>>();
            notyfService.Success(result.Messages);
            return View(BookListVMs);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bookCreateVM = new AdminBookCreateVM();
            bookCreateVM.Authors = await GetAuthors();
            bookCreateVM.Categories = await GetCategories();
            bookCreateVM.Publishers = await GetPublishers();
            return View(bookCreateVM);
        }

      

        [HttpPost]
        public async Task<IActionResult> Create(AdminBookCreateVM model)
        {
            var result = await _bookService.CreateAsync(model.Adapt<BookCreateDTO>());
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);
                return View(model);
            }
            NotifySuccess(result.Messages);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bookService.DeleteAsync(id);
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
            var result = await _bookService.GetByIdAsync(id);
            var bookUpdateVm = result.Data.Adapt<AdminBookUpdateVM>();
            bookUpdateVm.Authors = await GetAuthors();
            bookUpdateVm.Categories = await GetCategories();
            bookUpdateVm.Publishers = await GetPublishers();
            return View(bookUpdateVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminBookUpdateVM model)
        {
            var result = await _bookService.UpdateAsync(model.Adapt<BookUpdateDTO>());
            if (!result.IsSuccess)
            {
                notyfService.Error(result.Messages);
                return View(model);
            }
            notyfService.Success(result.Messages);

            return RedirectToAction("Index");
        }
        private async Task<SelectList> GetAuthors(Guid? authorId = null)
        {
            var authors = (await _authorService.GetAllAsync()).Data;
            return new SelectList(authors.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == (authorId != null ? authorId.Value : authorId)
            }).OrderBy(x => x.Text), "Value", "Text");
        }
        private async Task<SelectList> GetCategories(Guid? categoryId = null)
        {
            var categories = (await _categoryService.GetAllAsync()).Data;
            return new SelectList(categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == (categoryId != null ? categoryId.Value : categoryId)
            }).OrderBy(x => x.Text), "Value", "Text");
        }

        private async Task<SelectList> GetPublishers(Guid? publisherId = null)
        {
            var publishers = (await _publisherService.GetAllAsync()).Data;
            return new SelectList(publishers.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == (publisherId != null ? publisherId.Value : publisherId)
            }).OrderBy(x => x.Text), "Value", "Text");
        }

    }
}
