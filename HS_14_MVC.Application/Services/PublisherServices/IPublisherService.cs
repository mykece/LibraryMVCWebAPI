using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Application.DTOs.PublisherDTOs;
using HS_14_MVC.Domain.Utilities.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.Services.PublisherServices
{
    public interface IPublisherService
    {
        Task<IDataResult<PublisherDTO>> CreateAsync(PublisherCreateDTO publisherCreateDTO);
        Task<IDataResult<List<PublisherListDTO>>> GetAllAsync();
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<PublisherDTO>> GetByIdAsync(Guid id);
        Task<IDataResult<PublisherDTO>> UpdateAsync(PublisherUpdateDTO publisherUpdateDTO);
    }
}
