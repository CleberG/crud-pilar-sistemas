using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Book
{
    public class BookRequestDTO
    {
        public bool Ativo { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseData { get; set; }
        public string Status { get; set; }
    }
}
