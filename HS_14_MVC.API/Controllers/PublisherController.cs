using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Application.DTOs.PublisherDTOs;
using HS_14_MVC.Application.Services.PublisherServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_14_MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
       
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _publisherService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(PublisherCreateDTO publisherCreateDTO)
        {
            var result = await _publisherService.CreateAsync(publisherCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(PublisherUpdateDTO publisherUpdateDTO)
        {
            var result = await _publisherService.UpdateAsync(publisherUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _publisherService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }
    }
}
