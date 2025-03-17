using HS_14_MVC.Application.DTOs.AuthorDTOs;
using HS_14_MVC.Application.DTOs.PublisherDTOs;
using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Domain.Utilities.Concretes;
using HS_14_MVC.Domain.Utilities.İnterfaces;
using HS_14_MVC.Infrastructure.Repositories.PublisherRepositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.Services.PublisherServices
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<IDataResult<PublisherDTO>> CreateAsync(PublisherCreateDTO publisherCreateDTO)
        {
            if (await _publisherRepository.AnyAsync(x => x.Name.ToLower() == publisherCreateDTO.Name.ToLower()))
            {
                return new ErrorDataResult<PublisherDTO>("Mevcut Publisher Sistemde Kayıtlı!");
            }
            var newPublisher = publisherCreateDTO.Adapt<Publisher>();
            await _publisherRepository.AddAsync(newPublisher);
            await _publisherRepository.SaveChangesAsync();
            var publisherDTO = newPublisher.Adapt<PublisherDTO>();
            return new SuccessDataResult<PublisherDTO>(publisherDTO, "Publisher EKleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingPublisher = await _publisherRepository.GetByIdAsync(id);
            if (deletingPublisher == null)
            {
                return new ErrorResult("Silinecek Veri Bulunamadı");
            }
            await _publisherRepository.DeleteAsync(deletingPublisher);
            await _publisherRepository.SaveChangesAsync();
            return new SuccessResult("Publisher Silme İşlemi Başarılı");
        }

        public async Task<IDataResult<List<PublisherListDTO>>> GetAllAsync()
        {
            var publishers = await _publisherRepository.GetAllAsync();
            var publisherListDtos = publishers.Adapt<List<PublisherListDTO>>();
            if (publishers.Count() <= 0)
            {
                return new ErrorDataResult<List<PublisherListDTO>>(publisherListDtos,"Listenelecek Publisher Bulunamadı");
            }
            
            return new SuccessDataResult<List<PublisherListDTO>>(publisherListDtos, "Publisher Listeleme Başarılı");
        }

        public async Task<IDataResult<PublisherDTO>> GetByIdAsync(Guid id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            if (publisher is null)
            {
                return new ErrorDataResult<PublisherDTO>("Gösterilecek Publisher Bulunamadı");
            }
            var publisherDto = publisher.Adapt<PublisherDTO>();
            return new SuccessDataResult<PublisherDTO>(publisherDto, "Publisher Gösterme Başarılı");
        }

        public async Task<IDataResult<PublisherDTO>> UpdateAsync(PublisherUpdateDTO publisherUpdateDTO)
        {
            var updatingPublisher = await _publisherRepository.GetByIdAsync(publisherUpdateDTO.Id, false);
            if (updatingPublisher == null)
            {
                return new ErrorDataResult<PublisherDTO>("Güncellenecek Kategori Bulunamadı");
            }

            var updatedPublisher = publisherUpdateDTO.Adapt(updatingPublisher);
            await _publisherRepository.UpdateAsync(updatedPublisher);
            await _publisherRepository.SaveChangesAsync();


            return new SuccessDataResult<PublisherDTO>(updatedPublisher.Adapt<PublisherDTO>(), "Kategori Güncelleme Başarılı");
        }
    }
}
