using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book : BaseEntity
    {

        public bool Ativo { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseData { get; set; }
        public string Status { get; set; }
        public virtual List<Reservation> Reservations { get; set; }


        public Book(bool ativo, string name, string author, string synopsis, DateTime releaseData, string status)
        {
            Ativo = ativo;
            Name = name;
            Author = author;
            Synopsis = synopsis;
            ReleaseData = releaseData;
            Status = status;
        }

        protected Book()
        {
        }

        public void Update(bool ativo, string name, string author, string synopsis, DateTime releaseData, string status)
        {
            Ativo = ativo;
            Name = name;
            Author = author;
            Synopsis = synopsis;
            ReleaseData = releaseData;
            Status = status;
        }

        public void Desabilitar()
        {
            Ativo = false;
        }
    }
}
