using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.ReservationsDTO
{
    public class ReservationRequestDTO
    {
        public bool Ativo { get; set; }
        public DateTime WithDrawalDate { get; set; }

        public double Price { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
