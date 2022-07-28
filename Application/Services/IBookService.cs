using Application.Dto.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IBookService
    {
        Task Create(BookRequestDTO request);
        Task Update(Guid id, BookRequestDTO request);
        Task Delete(Guid id);
        Task<BookResponseDTO> GetById(Guid id);
        Task<IList<BookResponseDTO>> GetAll();
    }
}
