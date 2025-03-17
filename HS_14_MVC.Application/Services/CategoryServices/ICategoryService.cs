using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Domain.Utilities.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDTO>> CreateAsync(CategoryCreateDTO categoryCreateDTO);
        Task<IDataResult<List<CategoryListDTO>>> GetAllAsync();
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<CategoryDTO>> GetByIdAsync(Guid id);
        Task<IDataResult<CategoryDTO>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO);
        
        

    }
}
