using HS_14_MVC.Application.DTOs.ProfileUserDTOs;
using HS_14_MVC.Domain.Utilities.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.Services.ProfileUserServices
{
    public interface IProfileUserService
    {
        Task<IDataResult<List<ProfileUserListDTO>>> GetAllAsync();
        Task<IDataResult<ProfileUserDTO>> CreateAsync(ProfileUserCreateDTO profileUserCreateDTO);
        Task<IResult> DeleteAsync(Guid id);

        Task<IDataResult<ProfileUserDTO>> GetByIdAsync(Guid id);

        Task<IDataResult<ProfileUserDTO>> UpdateAsync(ProfileUserUpdateDTO profileUserUpdateDTO);

    }
}
