using HS_14_MVC.Application.DTOs.AuthorDTOs;
using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Domain.Utilities.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task<IDataResult<AuthorDTO>> CreateAsync(AuthorCreateDTO authorCreateDTO);
        Task<IDataResult<List<AuthorListDTO>>> GetAllAsync();
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<AuthorDTO>> GetByIdAsync(Guid id);
        Task<IDataResult<AuthorDTO>> UpdateAsync(AuthorUpdateDTO authorUpdateDTO);
    }
}
