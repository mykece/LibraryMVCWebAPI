using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Application.DTOs.ProfileUserDTOs;
using HS_14_MVC.Application.Services.ProfileUserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_14_MVC.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileUserController : ControllerBase
    {
        private readonly IProfileUserService _profileUserService;

        public ProfileUserController(IProfileUserService profileUserService)
        {
            _profileUserService = profileUserService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _profileUserService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(ProfileUserCreateDTO profileUserCreateDTO)
        {
            var result = await _profileUserService.CreateAsync(profileUserCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(ProfileUserUpdateDTO profileUserUpdateDTO)
        {
            var result = await _profileUserService.UpdateAsync(profileUserUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _profileUserService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
    }
}
