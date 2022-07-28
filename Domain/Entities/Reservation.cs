using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public bool Ativo { get; set; }
        public DateTime WithDrawalDate { get; set; }
        public double Price { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }

        protected Reservation()
        {

        }

        public Reservation(bool ativo, DateTime withDrawalDate, double price, Guid userId, Guid bookId)
        {
            Ativo = ativo;
            WithDrawalDate = withDrawalDate;
            Price = price;
            UserId = userId;
            BookId = bookId;
        }

        public void Update(bool ativo, DateTime withDrawalDate, double price, Guid userId, Guid bookId)
        {
            Ativo = ativo;
            WithDrawalDate = withDrawalDate;
            Price = price;
            UserId = userId;
            BookId = bookId;
        }

        public void Desabilitar()
        {
            Ativo = false;
        }
    }
}
