using System;
using System.Collections.Generic;
using System.Text;
using TwitterKata.Messages;

namespace TwitterKata
{
    public class User : IUser
    {
        private string _name;
        private IMessageContainer _messageContainer;

        public User()
        {
            _messageContainer = new MessageContainer();
        }

        public User(IMessageContainer messageContainer)
        {
            _messageContainer = messageContainer;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void AddMessage(string message)
        {
            _messageContainer.AddMessage(message);
        }

        public bool IsMyName(string name)
        {
            return _name == name;
        }

        public List<string> GetMessages()
        {
            return _messageContainer.GetMessagesAsText();
        }
    }
}
