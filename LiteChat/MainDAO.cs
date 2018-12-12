using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;

namespace LiteChat
{
    class MainDAO
    {
        static IMongoDatabase mongo = Database.getDatabase();
        public static List<FriendData> getAllFriend(string userID)
        {
            IMongoCollection<Friend> collection = mongo.GetCollection<Friend>("FriendS");
            var filter = Builders<Friend>.Filter.Eq(x => x.UserID, userID);
            var resultList = collection.Find(filter).ToList();
           // MessageBox.Show("DAO " + resultList.Count());
            List<FriendData> result = new List<FriendData>();
            while(resultList.Count() > 0)
            {
                result.Add(new FriendData(resultList[resultList.Count() - 1].FriendID));
                resultList.RemoveAt(resultList.Count() - 1);

            }


            return result;
        }
        public static bool insertFriend(String userId, String friendId)
        {
            IMongoCollection<Friend> collection = mongo.GetCollection<Friend>("FriendS");
            //self
            Friend friend = new Friend(userId, friendId);
            collection.InsertOne(friend);
            //friend
            friend = new Friend(friendId, userId);
            collection.InsertOne(friend);

            MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
    }
    class FriendData
    {
        string friID, friName;

        public FriendData(string friIDin)
        {
            friID = friIDin;
            friName = searchFriendName(friIDin);
        }

        public string FriID { get => friID; set => friID = value; }
        public string FriName { get => friName; set => friName = value; }

        private static string searchFriendName(string friendID)
        {
            try
            {
                IMongoDatabase mongo = Database.getDatabase();
                IMongoCollection<User> collection = mongo.GetCollection<User>("UserS");
                var filter = Builders<User>.Filter.Eq(x => x.UserID, friendID);
                var resultList = collection.Find(filter).ToList();
                //MessageBox.Show("friend " + resultList.Count());
                return resultList[0].Username;
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return null;
          
           
        }
    }


}
