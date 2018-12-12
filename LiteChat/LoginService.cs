using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat
{
    class LoginService
    {
        public static User searchUser(String id, String password)
        {
            return LoginDAO.searchUser(id, password);
        }
      
    }
}
