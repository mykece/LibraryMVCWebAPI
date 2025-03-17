using HS_14_MVC.Application.DTOs.BookDTOs;
using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Application.Services.BookServices;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_14_MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {  
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(BookCreateDTO bookCreateDTO)
        {
            var result = await _bookService.CreateAsync(bookCreateDTO);
            if (!result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bookService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(BookUpdateDTO bookUpdateDTO)
        {
            var result = await _bookService.UpdateAsync(bookUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
    }
}
