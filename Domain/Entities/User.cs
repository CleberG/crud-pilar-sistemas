using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public bool Ativo { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual List<Reservation> Reservation { get; set; }

        public User(bool ativo, string name, string login, string password)
        {
            Ativo = ativo;
            Name = name;
            Login = login;
            Password = password;
            
        }

        protected User()
        {
        }

        public void Update(bool ativo, string name, string login, string password)
        {
            Ativo = ativo;
            Name = name;
            Login = login;
            Password = password;
            
        }

        public void Desabilitar()
        {
            Ativo = false;
        }
    }
}
