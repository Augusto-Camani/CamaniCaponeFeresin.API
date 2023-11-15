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

        public BaseResponse ValidateUser(AuthenticationRequestBody authRequestBody)
        {
                BaseResponse response = new BaseResponse();
                User? userForLogin = _context.Users.SingleOrDefault(u => u.UserName == authRequestBody.UserName);
                if (userForLogin != null)
                {
                    if (userForLogin.Password == authRequestBody.Password)
                    {
                        response.Result = true;
                        response.Message = "loging Succesfull";
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = "wrong password";
                    }
                }
                else
                {
                    response.Result = false;
                    response.Message = "wrong email";
                }
                return response;
        }
    }
}
