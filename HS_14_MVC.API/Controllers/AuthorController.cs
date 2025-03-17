using HS_14_MVC.Application.DTOs.AuthorDTOs;
using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Application.Services.AuthorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_14_MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _authorService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(AuthorCreateDTO authorCreateDTO)
        {
            var result = await _authorService.CreateAsync(authorCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(AuthorUpdateDTO authorUpdateDTO)
        {
            var result = await _authorService.UpdateAsync(authorUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _authorService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
    }
}
