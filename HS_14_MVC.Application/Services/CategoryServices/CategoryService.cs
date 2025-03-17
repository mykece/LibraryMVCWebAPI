using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Domain.Utilities.Concretes;
using HS_14_MVC.Domain.Utilities.İnterfaces;
using HS_14_MVC.Infrastructure.Repositories.CategoryRepositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IDataResult<CategoryDTO>> CreateAsync(CategoryCreateDTO categoryCreateDTO)
        {
            if (await _categoryRepository.AnyAsync(x => x.Name.ToLower() == categoryCreateDTO.Name.ToLower()))
            {
                return new ErrorDataResult<CategoryDTO>("Mevcut Category Sistemde Kayıtlı!");
            }
            var newCategory = categoryCreateDTO.Adapt<Category>();
            await _categoryRepository.AddAsync(newCategory);
            await _categoryRepository.SaveChangesAsync();
            var categoryDTO = newCategory.Adapt<CategoryDTO>();
            return new SuccessDataResult<CategoryDTO>(categoryDTO, "Kategori EKleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingCategory = await _categoryRepository.GetByIdAsync(id);
            if (deletingCategory == null)
            {
                return new ErrorResult("Silinecek Veri Bulunamadı");
            }
            await _categoryRepository.DeleteAsync(deletingCategory);
            await _categoryRepository.SaveChangesAsync();
            return new SuccessResult("Kategori Silme İşlemi Başarılı");
        }

        public async Task<IDataResult<List<CategoryListDTO>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryListDtos = categories.Adapt<List<CategoryListDTO>>();
            if (categories.Count() <= 0)
            {
                return new ErrorDataResult<List<CategoryListDTO>>(categoryListDtos,"Listenelecek Kategori Bulunamadı");
            }
            
            return new SuccessDataResult<List<CategoryListDTO>>(categoryListDtos, "Kategori Listeleme Başarılı");
        }

        public async Task<IDataResult<CategoryDTO>> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return new ErrorDataResult<CategoryDTO>("Gösterilecek Category Bulunamadı");
            }
            var categoryDto = category.Adapt<CategoryDTO>();
            return new SuccessDataResult<CategoryDTO>(categoryDto, "Category Gösterme Başarılı");
        }

        public async Task<IDataResult<CategoryDTO>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO)
        {

            var updatingCategory = await _categoryRepository.GetByIdAsync(categoryUpdateDTO.Id,false);
            if (updatingCategory == null)
            {
                return new ErrorDataResult<CategoryDTO>("Güncellenecek Kategori Bulunamadı");
            }

            var updatedCategory = categoryUpdateDTO.Adapt(updatingCategory);
            await _categoryRepository.UpdateAsync(updatedCategory);
            await _categoryRepository.SaveChangesAsync();

            
            return new SuccessDataResult<CategoryDTO>(updatedCategory.Adapt<CategoryDTO>(), "Kategori Güncelleme Başarılı");
        }
    }
}
