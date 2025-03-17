using HS_14_MVC.Application.DTOs.BookDTOs;
using HS_14_MVC.Application.DTOs.CategoryDTOs;
using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Domain.Utilities.Concretes;
using HS_14_MVC.Domain.Utilities.İnterfaces;
using HS_14_MVC.Infrastructure.Repositories.BookRepositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IDataResult<BookDTO>> CreateAsync(BookCreateDTO bookCreateDTO)
        {
            if (await _bookRepository.AnyAsync(x => x.Name.ToLower() == bookCreateDTO.Name.ToLower()))
            {
                return new ErrorDataResult<BookDTO>("Kitap Ekleme Başarısız");
            }
            var newBook = bookCreateDTO.Adapt<Book>();
            await _bookRepository.AddAsync(newBook);
            await _bookRepository.SaveChangesAsync();
            var bookDTO = newBook.Adapt<BookDTO>();
            return new SuccessDataResult<BookDTO>(bookDTO, "Book EKleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var deletingBook = await _bookRepository.GetByIdAsync(id);
            if (deletingBook == null)
            {
                return new ErrorResult("Silinecek Veri Bulunamadı");
            }
            await _bookRepository.DeleteAsync(deletingBook);
            await _bookRepository.SaveChangesAsync();
            return new SuccessResult("Book Silme İşlemi Başarılı");
        }

        public async Task<IDataResult<List<BookListDTO>>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            var bookListDtos = books.Adapt<List<BookListDTO>>();
            if (books.Count() <= 0)
            {
                return new ErrorDataResult<List<BookListDTO>>(bookListDtos,"Listenelecek Book Bulunamadı");
            }
            
            return new SuccessDataResult<List<BookListDTO>>(bookListDtos, "Book Listeleme Başarılı");
        }

        public async Task<IDataResult<BookDTO>> GetByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is null)
            {
                return new ErrorDataResult<BookDTO>("Gösterilecek Kitap Bulunamadı");
            }
            var bookDto = book.Adapt<BookDTO>();
            return new SuccessDataResult<BookDTO>(bookDto, "Kitap Gösterme Başarılı");
        }

        public async Task<IDataResult<BookDTO>> UpdateAsync(BookUpdateDTO bookUpdateDTO)
        {
            var updatingBook = await _bookRepository.GetByIdAsync(bookUpdateDTO.Id, false);
            if (updatingBook == null)
            {
                return new ErrorDataResult<BookDTO>("Güncellenecek Kitap Bulunamadı");
            }

            var updatedBook = bookUpdateDTO.Adapt(updatingBook);
            await _bookRepository.UpdateAsync(updatedBook);
            await _bookRepository.SaveChangesAsync();


            return new SuccessDataResult<BookDTO>(updatedBook.Adapt<BookDTO>(), "Kitap Güncelleme Başarılı");
        }
    }
}
