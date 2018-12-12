using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat
{
    class UserService
    {

        public static User getUser(String id)
        {
            User user = UserDAO.getUser(id);
            if (user == null)
            {
                return null;
            }
            
            return user;
        }

        public static Boolean deleteUser(String id)
        {
            return UserDAO.deleteUser(id);
        }
    }
}