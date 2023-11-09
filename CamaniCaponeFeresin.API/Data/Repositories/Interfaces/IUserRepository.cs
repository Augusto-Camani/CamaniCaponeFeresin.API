using CamaniCaponeFeresin.API.Entities;

namespace CamaniCaponeFeresin.API.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public User GetByUserName(string name);
        public void Add(User product);
        public void Update(User product);
        public void Delete(int id);
    }
}
