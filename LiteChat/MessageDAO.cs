using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace LiteChat
{
    class MessageDAO
    {
        
        static IMongoCollection<BsonDocument> coll = Database.getDatabase().GetCollection<BsonDocument>("MessageS");
        static Queue<Message> msgstack = new Queue<Message>();
        public static void createMessage(Message msg)
        {
            try
            {
                BsonDocument msgdoc = new BsonDocument {
                { "Sender", msg.Sender},
                { "Reciever", msg.Reciever},
                { "MessageText", msg.MessageText},
                { "Status", "0" }
                };
                coll.InsertOneAsync(msgdoc);
                Console.WriteLine("(" + msg.Sender + " to " + msg.Reciever + ") : " + msg.MessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void hookMessage(User sender, User reciever)
        {
            var options = new ChangeStreamOptions { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };
            var change = getObjectCollection().Watch(options).ToEnumerable().GetEnumerator();
            while (change.MoveNext())
            {
                var query = Builders<Message>.Filter.Eq("Sender", sender.Username)
                           & Builders<Message>.Filter.Eq("Reciever", reciever.Username)
                           & Builders<Message>.Filter.Eq("Status", "0");
                var list = getObjectCollection().Find(query).ToList();
                foreach (Message DocMsg in list)
                {
                    Console.WriteLine(DocMsg.Sender + " to " + DocMsg.Reciever + " : " + DocMsg.MessageText);
                    msgstack.Enqueue(DocMsg);
                    UpdateReadStatus(DocMsg);

                }
            }
        }
        public static void pullAllMessage(User sender, User reciever)
        {
            var query = Builders<Message>.Filter.Eq("Sender", sender.Username)
                        & Builders<Message>.Filter.Eq("Reciever", reciever.Username)
                        |
                        Builders<Message>.Filter.Eq("Sender", reciever.Username)
                        & Builders<Message>.Filter.Eq("Reciever", sender.Username);
            var list = getObjectCollection().Find(query).ToList();
            foreach (Message DocMsg in list)
            {
                Console.WriteLine(DocMsg.Sender + " to " + DocMsg.Reciever + " : " + DocMsg.MessageText);
                msgstack.Enqueue(DocMsg);
                UpdateReadStatus(DocMsg);
            }
        }
        public static Queue<Message> getMessage()
        {
            return msgstack;
        }
        public static IMongoCollection<Message> getObjectCollection()
        {
            return Database.getDatabase().GetCollection<Message>("MessageS");
        }

        public static void UpdateReadStatus(Message DocMsg)
        {   
            //getObjectCollection().DeleteOneAsync(x => x._id == DocMsg._id);
            var update = Builders<Message>.Update.Set("Status", "1");
            FilterDefinition<Message> filter = Builders<Message>.Filter.Eq("_id", DocMsg._id);
            getObjectCollection().UpdateOneAsync(filter, update);
        }
    }
}