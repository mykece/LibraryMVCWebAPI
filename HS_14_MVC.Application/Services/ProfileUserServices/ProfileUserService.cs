using HS_14_MVC.Application.DTOs.ProfileUserDTOs;
using HS_14_MVC.Application.Services.AccountServices;
using HS_14_MVC.Domain.Utilities.İnterfaces;
using HS_14_MVC.Infrastructure.Repositories.ProfileUserRepositories;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HS_14_MVC.Domain.Utilities.Concretes;
using Microsoft.AspNetCore.Identity;
using HS_14_MVC.Domain.Enums;
using Mapster;
using HS_14_MVC.Domain.Entities;

namespace HS_14_MVC.Application.Services.ProfileUserServices
{
    public class ProfileUserService : IProfileUserService
    {
        private readonly IAccountService _accountService;
        private readonly IProfileUserRepository _profileUserRepository;

        public ProfileUserService(IAccountService accountService, IProfileUserRepository profileUserRepository)
        {
            _accountService = accountService;
            _profileUserRepository = profileUserRepository;
        }

        public async Task<IDataResult<ProfileUserDTO>> CreateAsync(ProfileUserCreateDTO profileUserCreateDTO)
        {
            if (await _accountService.AnyAsync(x => x.Email == profileUserCreateDTO.Email))
            {
                return new ErrorDataResult<ProfileUserDTO>("Email Kullanılıyor");
            }
            IdentityUser identityUser = new()
            {
                Email = profileUserCreateDTO.Email,
                NormalizedEmail = profileUserCreateDTO.Email.ToLowerInvariant(),
                UserName = profileUserCreateDTO.Email,
                NormalizedUserName = profileUserCreateDTO.Email.ToUpperInvariant(),
                EmailConfirmed = true

            };
            DataResult<ProfileUserDTO> result = new ErrorDataResult<ProfileUserDTO>();
            var strategy = await _profileUserRepository.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                var transactionScope = await _profileUserRepository.BeginTransactionAsync().ConfigureAwait(false);
                try
                {
                    var identityResult = await _accountService.CrateUserAsync(identityUser, Roles.AppUser);
                    if (!identityResult.Succeeded)
                    {
                        result = new ErrorDataResult<ProfileUserDTO>(identityResult.ToString());
                        transactionScope.Rollback();
                        return;
                    }
                    var profileUser = profileUserCreateDTO.Adapt<AppUser>();
                    profileUser.IdentityId = identityUser.Id;
                    await _profileUserRepository.AddAsync(profileUser);
                    await _profileUserRepository.SaveChangesAsync();
                    result = new SuccessDataResult<ProfileUserDTO>("Kullanıcı Ekleme Başarılı");
                    transactionScope.Commit();
                }
                catch (Exception ex)
                {
                    result = new ErrorDataResult<ProfileUserDTO>("Ekleme Başarısız" + ex.Message);
                    transactionScope.Rollback();
                }
                finally
                {
                    transactionScope.Dispose();
                }


            });
            return result;
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            Result result = new ErrorResult();
            // Transaction ve strateji başlat
            var strategy = await _profileUserRepository.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                var transactionScope = await _profileUserRepository.BeginTransactionAsync().ConfigureAwait(false);
                try
                {
                    // Silinecek kullanıcıyı ID ile getir
                    var deletingUser = await _profileUserRepository.GetByIdAsync(id);
                    if (deletingUser == null)
                    {
                        result = new ErrorResult("Silinecek Kullanıcı Bulunamadı");
                        transactionScope.Rollback();
                        return;
                    }

                    // IdentityUser'ı sil
                    var identityResult = await _accountService.DeleteUserAsync(deletingUser.IdentityId);
                    if (!identityResult.Succeeded)
                    {
                        result = new ErrorResult("Kullanıcı Silme İşlemi Başarısız: " + string.Join(", ", identityResult.Errors.Select(e => e.Description)));
                        transactionScope.Rollback();
                        return;
                    }

                    // AppUser'ı sil ve değişiklikleri kaydet
                    await _profileUserRepository.DeleteAsync(deletingUser);
                    await _profileUserRepository.SaveChangesAsync();
                    result = new SuccessResult("Kullanıcı Silme İşlemi Başarılı");
                    transactionScope.Commit();
                }
                catch (Exception ex)
                {
                    result = new ErrorResult("Silme İşlemi Başarısız: " + ex.Message);
                    transactionScope.Rollback();
                }
                finally
                {
                    transactionScope.Dispose();
                }
            });
            return result;
        }


        public async Task<IDataResult<List<ProfileUserListDTO>>> GetAllAsync()
        {
            var profileUsers = await _profileUserRepository.GetAllAsync();
            var profileUserDTOs = profileUsers.Adapt<List<ProfileUserListDTO>>();
            if (profileUsers.Count() <= 0)
            {
                return new ErrorDataResult<List<ProfileUserListDTO>>(profileUserDTOs, "Görüntülenecek kullanıcı bulunamadı");
            }
            return new SuccessDataResult<List<ProfileUserListDTO>>(profileUserDTOs,"Kullanıcı listeleme başarılı");
        }

        public async Task<IDataResult<ProfileUserDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                // Kullanıcıyı ID'si ile veritabanından çek
                var profileUser = await _profileUserRepository.GetByIdAsync(id);
                if (profileUser == null)
                {
                    // Kullanıcı bulunamadıysa hata döndür
                    return new ErrorDataResult<ProfileUserDTO>("Kullanıcı Bulunamadı");
                }

                // Kullanıcıyı DTO'ya dönüştür
                var profileUserDTO = profileUser.Adapt<ProfileUserDTO>();

                // Başarı ile döndür
                return new SuccessDataResult<ProfileUserDTO>(profileUserDTO, "Kullanıcı Başarıyla Getirildi");
            }
            catch (Exception ex)
            {
                // Herhangi bir hata oluşursa hata mesajı ile döndür
                return new ErrorDataResult<ProfileUserDTO>("Kullanıcı Getirme İşlemi Başarısız: " + ex.Message);
            }
        }

        public async Task<IDataResult<ProfileUserDTO>> UpdateAsync(ProfileUserUpdateDTO profileUserUpdateDTO)
        {
            DataResult<ProfileUserDTO> result = new ErrorDataResult<ProfileUserDTO>();
            // Transaction ve strateji başlat
            var strategy = await _profileUserRepository.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                var transactionScope = await _profileUserRepository.BeginTransactionAsync().ConfigureAwait(false);
                try
                {
                    // Güncellenecek kullanıcıyı ID ile getir
                    var updatingUser = await _profileUserRepository.GetByIdAsync(profileUserUpdateDTO.Id, false);
                    if (updatingUser == null)
                    {
                        result = new ErrorDataResult<ProfileUserDTO>("Güncellenecek Kullanıcı Bulunamadı");
                        transactionScope.Rollback();
                        return;
                    }

                    // Kullanıcıyı DTO'dan güncelle ve değişiklikleri kaydet
                    updatingUser = profileUserUpdateDTO.Adapt(updatingUser);
                    await _profileUserRepository.UpdateAsync(updatingUser);
                    await _profileUserRepository.SaveChangesAsync();
                    result = new SuccessDataResult<ProfileUserDTO>(updatingUser.Adapt<ProfileUserDTO>(), "Kullanıcı Güncelleme Başarılı");
                    transactionScope.Commit();
                }
                catch (Exception ex)
                {
                    result = new ErrorDataResult<ProfileUserDTO>("Güncelleme Başarısız: " + ex.Message);
                    transactionScope.Rollback();
                }
                finally
                {
                    transactionScope.Dispose();
                }
            });
            return result;
        }
    }
}
