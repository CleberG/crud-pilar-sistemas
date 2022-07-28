using Application.Dto.Book;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Create(BookRequestDTO request)
        {
            var book = new Book(request.Ativo, request.Name, request.Author, request.Synopsis, request.ReleaseData, request.Status);

            await _bookRepository.Create(book);

        }

        public async Task Delete(Guid id)
        {
            var bookExist = await _bookRepository.CheckExistence(id);
            if (!bookExist)
            {
                throw new NotImplementedException("Livro não existe.");
            }

            var book = await _bookRepository.GetById(id);
            book.Desabilitar();
        }

        public async Task<IList<BookResponseDTO>> GetAll()
        {
            var books =  _bookRepository
                .GetAll()
                .ToList();
            return books.Select( d => new BookResponseDTO()
            {
                Id = d.Id,
                Name = d.Name,
                Author = d.Author,
                Synopsis = d.Synopsis,
                ReleaseData = d.ReleaseData,
                Status = d.Status,
            }).ToList();
        }

        public async Task<BookResponseDTO> GetById(Guid id)
        {
            var book = await _bookRepository.GetById(id);

            return new BookResponseDTO()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Synopsis = book.Synopsis,
                ReleaseData = book.ReleaseData,
                Status = book.Status,
            };
        }

        public async Task Update(Guid id, BookRequestDTO request)
        {
            var bookExist = await _bookRepository.CheckExistence(id);
            if (!bookExist)
            {
                throw new NotImplementedException("Livro não existe.");
            }

            var book = await _bookRepository.GetById(id);
            book.Update(request.Ativo, request.Name, request.Author, request.Synopsis, request.ReleaseData, request.Status);
            await _bookRepository.Update(id, book);
        }
    }
}
