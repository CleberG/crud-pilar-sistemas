using Application.Dto.ReservationsDTO;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;



        public ReservationService(IReservationRepository reservationRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task Create(ReservationRequestDTO request)
        {
            var user = await _userRepository.GetById(request.UserId);
            var book = await _bookRepository.GetById(request.BookId);

            var reservs = await _reservationRepository.GetByUserId(request.UserId);

            foreach (var item in reservs)
            {

                var finalDate = item.WithDrawalDate.AddDays(30);
                var dateNow = DateTime.Today;
                if (item.Book.Name == book.Name && finalDate > dateNow )
                {
                    throw new ArgumentException($"{item.Book.Name} já esta reservado");
                }
            }

            foreach (var item in reservs)
            {
                var multa = 0.0;
                var totalDias = (item.WithDrawalDate - DateTime.Today).TotalDays;
                var dias2 = item.WithDrawalDate.Subtract(DateTime.Now);
                double dias3 = dias2.Days;
                var diasDeMulta = totalDias - 30;
                if (diasDeMulta > 0)
                {
                    multa = 10.0 * (1 + (0.01 * diasDeMulta));

                }

            }


            var reservation = new Reservation(request.Ativo, request.WithDrawalDate, request.Price, request.UserId, request.BookId);
            await _reservationRepository.Create(reservation);
        }

        public async Task Delete(Guid id)
        {
            var reservation = await _reservationRepository.GetById(id);
            reservation.Desabilitar();
            await _reservationRepository.Update(id, reservation);
        }

        public async Task<IList<ReservationResponseDTO>> GetAll()
        {
            var reservation = _reservationRepository.GetAll();

            return reservation.Select(d => new ReservationResponseDTO()
            {
                Id = d.Id,
                Ativo = d.Ativo,
                WithDrawalDate = d.WithDrawalDate,
                UserId = d.UserId,
                User = d.User,
                BookId = d.BookId,
                Book = d.Book,
            }).ToList();
        }

        public async Task<ReservationResponseDTO> GetById(Guid id)
        {
            var reservation = await _reservationRepository.GetById(id);

            return new ReservationResponseDTO()
            {
                Id = reservation.Id,
                Ativo = reservation.Ativo,
                WithDrawalDate = reservation.WithDrawalDate,
                UserId = reservation.UserId,
                User = reservation.User,
                BookId = reservation.BookId,
                Book = reservation.Book,
            };
        }

        public async Task Update(Guid id, ReservationRequestDTO request)
        {
            var reservationExist = await _bookRepository.CheckExistence(id);
            if (!reservationExist)
            {
                throw new NotImplementedException("A reserva não existe.");
            }
            var reservation = await _reservationRepository.GetById(id);
            var user = await _userRepository.GetById(request.UserId);
            var book = await _bookRepository.GetById(request.BookId);
            reservation.Update(request.Ativo, request.WithDrawalDate, request.Price, request.UserId, request.BookId);
            await _reservationRepository.Update(id, reservation);
        }
    }
}
