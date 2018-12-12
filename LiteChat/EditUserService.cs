using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat
{
    class EditUserService
    {
        public void editUser(User user)
        {
            EditUserDAO edt = new EditUserDAO();
            edt.editUser(user);
        }
    }
}
