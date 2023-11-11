using AutoMapper;
using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.Entities;
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
        public void Add(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _userRepository.Add(user);
        }
        public void Update(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _userRepository.Update(user);
        }
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
