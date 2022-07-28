using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.ReservationsDTO
{
    public class ReservationsDtoBase : DTOBase
    {
        public DateTime WithDrawalDate { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid BookId { get; set; }
        public virtual Domain.Entities.Book Book { get; set; }
    }
}
