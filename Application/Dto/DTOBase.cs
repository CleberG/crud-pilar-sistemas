using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public abstract class DTOBase
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
    }
}
