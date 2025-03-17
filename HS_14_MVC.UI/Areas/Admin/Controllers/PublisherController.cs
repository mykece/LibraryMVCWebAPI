using HS_14_MVC.Application.DTOs.AuthorDTOs;
using HS_14_MVC.Application.DTOs.PublisherDTOs;
using HS_14_MVC.Application.Services.AuthorServices;
using HS_14_MVC.Application.Services.PublisherServices;
using HS_14_MVC.UI.Areas.Admin.Models.AuthorVMs;
using HS_14_MVC.UI.Areas.Admin.Models.PublisherVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HS_14_MVC.UI.Areas.Admin.Controllers
{
    public class PublisherController : AdminBaseController
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _publisherService.GetAllAsync();
            if (!result.IsSuccess)
            {
                notyfService.Error(result.Messages);
                return View();
            }

            var PbulisherListVMs = result.Data.Adapt<List<AdminPublisherListVM>>();
            notyfService.Success(result.Messages);
            return View(PbulisherListVMs);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminPublisherCreateVM model)
        {
            var publisherDTO = model.Adapt<PublisherCreateDTO>();
            var result = await _publisherService.CreateAsync(publisherDTO);
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
            var result = await _publisherService.DeleteAsync(id);
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
            var result = await _publisherService.GetByIdAsync(id);
            var publisherUpdateVm = result.Data.Adapt<AdminPublisherUpdateVM>();
            return View(publisherUpdateVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminPublisherUpdateVM model)
        {
            var result = await _publisherService.UpdateAsync(model.Adapt<PublisherUpdateDTO>());
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
