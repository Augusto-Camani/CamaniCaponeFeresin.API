using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public User GetByUserName(string name);
        public void Add(UserDTO userDTO);
        public void Update(UserDTO userDTO);
        public void Delete(int id);
    }
}
