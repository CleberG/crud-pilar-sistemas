using Application.Dto.ReservationsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IReservationService
    {
        Task Create(ReservationRequestDTO request);
        Task Update(Guid id, ReservationRequestDTO request);
        Task Delete(Guid id);
        Task<ReservationResponseDTO> GetById(Guid id);
        Task<IList<ReservationResponseDTO>> GetAll();
    }
}
