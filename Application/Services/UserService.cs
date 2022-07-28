using Application.Dto.UserDTO;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Create(UserRequestDTO request)
        {
            var user = new User(request.Ativo, request.Name, request.Login, request.Password);
            await _userRepository.Create(user);
        }

        public async Task Delete(Guid id)
        {
            var user = await _userRepository.GetById(id);
            user.Desabilitar();
            await _userRepository.Update(id, user);
        }

        public async Task<IList<UserResponseDTO>> GetAll()
        {
            var user = _userRepository
                .GetAll()
                .ToList();

            return user.Select(d => new UserResponseDTO()
            {
                Id = d.Id,
                Ativo = d.Ativo,
                Name = d.Name,
                Login = d.Login,
                Password = d.Password,
            }).ToList();

        }

        public async Task<UserResponseDTO> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);

            return new UserResponseDTO()
            {
                Id = user.Id,
                Ativo = user.Ativo,
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,
            };
        }

        public async Task Update(Guid id, UserRequestDTO request)
        {
            var user = await _userRepository.GetById(id);
            user.Update(request.Ativo, request.Name, request.Login, request.Password);
            await _userRepository.Update(id, user);
        }
    }
}
