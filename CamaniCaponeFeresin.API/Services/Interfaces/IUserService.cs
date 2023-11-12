using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Enums;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public User GetByUserName(string name);
        public void AddClient(UserDTO userDTO);
        public void AddAdmin(UserDTO userDTO);
        public void Update(int id , UserDTO userDTO);
        public void Delete(int id);
    }
}
