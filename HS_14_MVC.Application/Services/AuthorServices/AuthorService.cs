using HS_14_MVC.Application.DTOs.AuthorDTOs;
using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Domain.Utilities.Concretes;
using HS_14_MVC.Domain.Utilities.İnterfaces;
using HS_14_MVC.Infrastructure.Repositories.AuthorRepositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.Services.AuthorServices;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IDataResult<AuthorDTO>> CreateAsync(AuthorCreateDTO authorCreateDTO)
    {
        if (await _authorRepository.AnyAsync(x => x.Name.ToLower() == authorCreateDTO.Name.ToLower()))
        {
            return new ErrorDataResult<AuthorDTO>("Mevcut Author Sistemde Kayıtlı!");
        }
        var newAuthor = authorCreateDTO.Adapt<Author>();
        await _authorRepository.AddAsync(newAuthor);
        await _authorRepository.SaveChangesAsync();
        var authorDTO = newAuthor.Adapt<AuthorDTO>();
        return new SuccessDataResult<AuthorDTO>(authorDTO, "Author EKleme Başarılı");
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var deletingAuthor = await _authorRepository.GetByIdAsync(id);
        if (deletingAuthor == null)
        {
            return new ErrorResult("Silinecek Veri Bulunamadı");
        }
        await _authorRepository.DeleteAsync(deletingAuthor);
        await _authorRepository.SaveChangesAsync();
        return new SuccessResult("Author Silme İşlemi Başarılı");
    }

    public async Task<IDataResult<List<AuthorListDTO>>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        var authorListDtos = authors.Adapt<List<AuthorListDTO>>();
        if (authors.Count() <= 0)
        {
            return new ErrorDataResult<List<AuthorListDTO>>(authorListDtos,"Listenelecek Author Bulunamadı");
        }
        ;
        return new SuccessDataResult<List<AuthorListDTO>>(authorListDtos, "Author Listeleme Başarılı");
    }

    public async Task<IDataResult<AuthorDTO>> GetByIdAsync(Guid id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author is null)
        {
            return new ErrorDataResult<AuthorDTO>("Gösterilecek Author Bulunamadı");
        }
        var authorDto = author.Adapt<AuthorDTO>();
        return new SuccessDataResult<AuthorDTO>(authorDto, "Author Gösterme Başarılı");
    }

    public async Task<IDataResult<AuthorDTO>> UpdateAsync(AuthorUpdateDTO authorUpdateDTO)
    {
        var updatingAuthor = await _authorRepository.GetByIdAsync(authorUpdateDTO.Id, false);
        if (updatingAuthor == null)
        {
            return new ErrorDataResult<AuthorDTO>("Güncellenecek Kategori Bulunamadı");
        }

        var updatedAuthor = authorUpdateDTO.Adapt(updatingAuthor);
        await _authorRepository.UpdateAsync(updatedAuthor);
        await _authorRepository.SaveChangesAsync();


        return new SuccessDataResult<AuthorDTO>(updatedAuthor.Adapt<AuthorDTO>(), "Kategori Güncelleme Başarılı");
    }
}

   


