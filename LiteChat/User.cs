using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat
{
    public class User
    {
        private String username;
        private String password;
        private String userId;
        public ObjectId _id { get; set; }

        //mock
        public User (String username)
        {
            this.username = username;
        }

        public User(String userId,
                    String username,
                    String password){
            this.Username = username;
            this.Password = password;
            this.UserID = userId;
            
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string UserID { get => userId; set => userId = value; }
        
    }
}
