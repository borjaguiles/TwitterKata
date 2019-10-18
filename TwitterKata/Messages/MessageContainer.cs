using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterKata.Messages
{
    public class MessageContainer : IMessageContainer
    {
        private List<Message> Message;

        public MessageContainer()
        {
            Message = new List<Message>();
        }

        public void AddMessage(string message)
        {
            Message.Add(new Message(message));
        }

        public List<string> GetMessagesAsText()
        {
            return Message.Select( s => s.GetContentAndStamp()).ToList();
        }
    }
}
