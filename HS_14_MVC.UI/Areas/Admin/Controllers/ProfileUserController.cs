using HS_14_MVC.Application.DTOs.ProfileUserDTOs;
using HS_14_MVC.Application.DTOs.PublisherDTOs;
using HS_14_MVC.Application.Services.ProfileUserServices;
using HS_14_MVC.Application.Services.PublisherServices;
using HS_14_MVC.UI.Areas.Admin.Models.ProfileUserVMs;
using HS_14_MVC.UI.Areas.Admin.Models.PublisherVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HS_14_MVC.UI.Areas.Admin.Controllers
{
    public class ProfileUserController : AdminBaseController
    {
        private readonly IProfileUserService _profileUserService;

        public ProfileUserController(IProfileUserService profileUserService)
        {
            _profileUserService = profileUserService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _profileUserService.GetAllAsync();
            var profileUserListVMs = result.Data.Adapt<List<AdminProfileUserListVM>>();
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);
                return View(profileUserListVMs);
            }


            NotifySuccess(result.Messages);
            return View(profileUserListVMs);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminProfileUserCreateVM model)
        {
            var profileUserDTO = model.Adapt<ProfileUserCreateDTO>();
            var result = await _profileUserService.CreateAsync(profileUserDTO);
            if (!result.IsSuccess)
            {
                NotifyError(result.Messages);
                return View(model);
            }
            NotifySuccess(result.Messages);
            return RedirectToAction("Index");
        }

    }
}
