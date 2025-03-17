using HS_14_MVC.Application.DTOs.BookDTOs;
using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Application.DTOs.PublisherDTOs;
using HS_14_MVC.Domain.Utilities.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.Services.BookServices
{
    public interface IBookService
    {
        Task<IDataResult<BookDTO>> CreateAsync(BookCreateDTO bookCreateDTO);
        Task<IDataResult<List<BookListDTO>>> GetAllAsync();
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<BookDTO>> GetByIdAsync(Guid id);
        Task<IDataResult<BookDTO>> UpdateAsync(BookUpdateDTO bookUpdateDTO);
    }
}
