using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat
{
    class RegisterService
    {
        public static void insertUser(User user)
        {
            UserDAO.insertUser(user);
        }
        public static Boolean getUser(String id)
        {
            if (UserDAO.getUser(id) == null)
            {
                return false;
            }
           return true;
        }
    }
}
