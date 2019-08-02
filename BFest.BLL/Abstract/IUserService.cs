using BFest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFest.BLL.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        User GetUserByLogin(string Email, string password);
        User GetUserByEmail(string email);

        User GetAdminByLogin(string Email, string password);


    }
}
