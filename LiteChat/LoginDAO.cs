using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteChat
{
    class LoginDAO
    {
        public static User searchUser(String id, String password)
        {
            try
            {
                IMongoDatabase mongo = Database.getDatabase();
                IMongoCollection<User> collection = mongo.GetCollection<User>("UserS");
                //var filter = Builders<User>.Filter.Eq(x => x.UserID, id)& 
                //    Builders<User>.Filter.Eq(x => x.Password, password);
                FilterDefinition<User> query = Builders<User>.Filter.Eq("UserID", id);
                return collection.Find(query).First();
            }
            catch (Exception e)
            {
               // MessageBox.Show(e.ToString());
            }
            return null;
        }
    }
}
