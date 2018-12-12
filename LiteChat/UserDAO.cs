using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat
{
    class UserDAO
    {
        private static IMongoCollection<User> collection = Database.getDatabase().GetCollection<User>("UserS");

        public static void insertUser(User user)
        {
            collection.InsertOne(user);
        }

        public static User getUser(String id)
        {
            try
            {
                FilterDefinition<User> query = Builders<User>.Filter.Eq("UserID", id);
                return collection.Find(query).First();
            }catch(Exception e)
            {
                return null;
            }
           
        }

        public static bool deleteUser(String id)
        {
            try
            {
                FilterDefinition<User> query = Builders<User>.Filter.Eq("UserID", id);
                collection.DeleteOne(query);
                IMongoCollection<Friend> collection2 = Database.getDatabase().GetCollection<Friend>("FriendS");
                FilterDefinition<Friend> query2 = Builders<Friend>.Filter.Eq("FriendID", id);
                collection2.DeleteMany(query2);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
           
        }
    }
}