using AutoMapper;
using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Enums;
using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;

namespace CamaniCaponeFeresin.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public User GetById(int id)
        {
            return  _userRepository.GetById(id);
        }
        public User GetByUserName(string name)
        {
            return _userRepository.GetByUserName(name);
        }
        public void AddClient(UserDTO userDTO)
        {
            var user = _mapper.Map<Client>(userDTO);
            _userRepository.AddClient(user);
        }

        public void AddAdmin(UserDTO userDTO)
        {
            var admin = _mapper.Map<Admin>(userDTO);
            _userRepository.AddAdmin(admin);
        }

        public void Update(int id, UserDTO userDTO)
        {
            var existingUser = _userRepository.GetById(id);

            if (existingUser == null)
            {
                // Manejar el caso en el que el producto no existe
                throw new Exception("Producto no encontrado");
            }

            // Mapear las propiedades relevantes del DTO a la entidad existente
            existingUser.UserName = userDTO.UserName;
            existingUser.Email = userDTO.Email;
            existingUser.Password = userDTO.Password;

            // Actualizar la entidad en el repositorio
            _userRepository.Update(existingUser);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
