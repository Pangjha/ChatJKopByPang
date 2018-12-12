using MongoDB.Driver;
using System;

namespace LiteChat
{
    public class Database
    {
        public static MongoUrl url = new MongoUrl("mongodb://lc:lclc@125.27.10.67:27017/LiteChat");
        public static MongoClient client = new MongoClient(url);
        public static IMongoDatabase mongo = client.GetDatabase("LiteChat");
        
        public static Boolean checkConnectionDB()
        {
            try
            {
                client.GetDatabase("user");
                Console.WriteLine("Connected to database.");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static IMongoDatabase getDatabase()
        {
            return client.GetDatabase("LiteChat");
        }


    }
   

}
