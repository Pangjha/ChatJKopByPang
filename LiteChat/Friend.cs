using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat
{
    class Friend
    {
        public ObjectId _id { get; set; }
        private String userID;
        private String friendID;

        public Friend(string userID, string friendID)
        {
            this.userID = userID;
            this.friendID = friendID;
        }

        public string UserID { get => userID; set => userID = value; }
        public string FriendID { get => friendID; set => friendID = value; }
    }
}
