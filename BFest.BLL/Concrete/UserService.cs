
using BFest.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFest.Model;
using BFest.BLL.Abstract;


namespace BFest.BLL.Concrete
{
    public class UserService : IUserService
    {
        IUserDAL _userDAL;

        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        //It deletes selected user.
        public void Delete(User entity)
        {
            _userDAL.Remove(entity);
        }

        //It deletes an user according to ID.
        public void DeleteByID(int entityID)
        {
            User user = _userDAL.Get(z => z.ID == entityID);
            _userDAL.Remove(user);
        }

        //It brings selected user.
        public User Get(int entityID)
        {
            return _userDAL.Get(z => z.ID == entityID);
        }

        //It brings all users.
        public ICollection<User> GetAll()
        {
            return _userDAL.GetAll();
        }

        //It adds new user.
        public void Insert(User entity)
        {            
            _userDAL.Add(entity);
        }

        //It updates selected user.
        public void Update(User entity)
        {
            _userDAL.Update(entity);
        }

        //It gets an user according to mail and password.
        public User GetUserByLogin(string Email, string password)
        {
            return _userDAL.Get(a => a.Email == Email && a.Password == password);
        }

        //It gets an user according to mail address.
        public User GetUserByEmail(string email)
        {
            return _userDAL.Get(a => a.Email == email);
        }

        //It gets the admin according to mail and password.
        public User GetAdminByLogin(string Email, string password)
        {
            return _userDAL.Get(a => a.Email == Email && a.Password == password && a.Authority == true);
        }

    }
}
