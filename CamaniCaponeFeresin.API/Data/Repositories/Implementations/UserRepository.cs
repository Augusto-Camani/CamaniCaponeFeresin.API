using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

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
        public void AddClient(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void AddAdmin(User admin) 
        {
            _context.Add(admin);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
           _context.Update(user);
           _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(GetById(id));
            _context.SaveChanges();
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            if (authRequestBody.UserType == "Client")
                return _context.Clients.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
            return _context.Admins.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }
    }
}
