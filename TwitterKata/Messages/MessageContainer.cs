using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterKata.Messages
{
    public class MessageContainer : IMessageContainer
    {
        private List<Message> _messages;

        public MessageContainer()
        {
            _messages = new List<Message>();
        }

        public void AddMessage(string message)
        {
            _messages.Add(new Message(message));
        }

        public List<string> GetMessagesAsText()
        {
            return _messages.Select( s => s.GetContentAndStamp()).ToList();
        }

        public List<Message> GetMessages()
        {
            return _messages;
        }
    }
}
