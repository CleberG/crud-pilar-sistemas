using Application.Dto.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task Create(UserRequestDTO request);
        Task Update(Guid id, UserRequestDTO request);
        Task Delete(Guid id);
        Task<UserResponseDTO> GetById(Guid id);
        Task<IList<UserResponseDTO>> GetAll();
    }
}
