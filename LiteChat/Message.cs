using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat
{
  
    class Message
    {
        private String messageText;
        private String status;
        private String sender;
        private String reciever;
        public ObjectId _id { get; set; }
        public Message(string message, string sender, string reciever)
        {
            this.MessageText = message;
       
            this.Sender = sender;
            this.Reciever = reciever;
        }

        public string MessageText { get => messageText; set => messageText = value; }
        public string Sender { get => sender; set => sender = value; }
        public string Reciever { get => reciever; set => reciever = value; }
        public string Status { get => status; set => status = value; }
    }
}
