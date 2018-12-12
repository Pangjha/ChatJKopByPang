using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat
{
    class MainService
    {
        public static List<FriendData> getAllFriend(string userID)
        {

            return MainDAO.getAllFriend(userID);
        }
        public static bool SearchFromList(String friendID, List<FriendData> friendlist)
        {
            foreach (FriendData i in friendlist)
            {
                if (i.FriID.Equals(friendID))
                {
                    //Console.WriteLine("found 1");
                    return false;
                }
            }
            return true;
        }

        public static bool checkIfFriendExist(String friendID)
        {
            //Console.WriteLine(UserDAO.getUser(friend.UserID).UserID);
            //Console.WriteLine(friendID);
            if (UserService.getUser(friendID)!=null)
            {
                return true;
            }
            else
            {
                Console.WriteLine(UserService.getUser(friendID));
            }

            return false;
        }

        internal static void SearchFromList()
        {
            throw new NotImplementedException();
        }


        public static bool insertFriend(String userId, String friendId)
        {
            MainDAO.insertFriend(userId, friendId);
            return true;
        }
    }
}
