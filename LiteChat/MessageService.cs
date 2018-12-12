using System.Collections.Generic;
namespace LiteChat
{
    class MessageService
    {
        public static void serveMessageIncoming(User sender, User reciever)
        {
            MessageDAO.hookMessage(sender, reciever);
        }

        public static void fetchAllMessage(User sender, User reciever)
        {
            MessageDAO.pullAllMessage(sender, reciever);
        }
        public static void InsertMessage(Message DocMsg)
        {
            MessageDAO.createMessage(DocMsg);
        }
        public static Queue<Message> getMessage()
        {
            return MessageDAO.getMessage();
        }
    }
}
