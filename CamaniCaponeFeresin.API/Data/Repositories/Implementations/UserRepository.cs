using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.DBContext;
using CamaniCaponeFeresin.API.Entities;

namespace CamaniCaponeFeresin.API.Data.Repositories.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(DBContext.AppDBContext context) : base(context) 
        {
            
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
           return _context.Users.Find(id);
        }

        public User GetByUserName(string name)
        {
            return _context.Users.SingleOrDefault( u => u.UserName == name);
        }
        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Update(User product)
        {
           _context.Update(product);
           _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
