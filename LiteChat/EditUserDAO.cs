using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat
{
    class EditUserDAO
    {
        public static IMongoCollection<User> getObjectCollection()
        {
            return Database.getDatabase().GetCollection<User>("UserS");
        }

        public void editUser(User user)
        {
            var update = Builders<User>.Update.Set("Username", user.Username).Set("Password", user.Password);
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", user._id);
            getObjectCollection().UpdateOneAsync(filter, update);
        }
    }
}
