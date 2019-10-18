using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterKata.Application.Users;
using TwitterKata.Messages;

namespace TwitterKata
{
    public class User
    {
        private string _name;
        private IMessageContainer _messageContainer;
        private IFollowedUsersContainer _followedUsersContainer;

        public User()
        {
            _messageContainer = new MessageContainer();
            _followedUsersContainer = new FollowedUsersContainer();
        }

        public User(IMessageContainer messageContainer, IFollowedUsersContainer followedUsersContainer)
        {
            _messageContainer = messageContainer;
            _followedUsersContainer = followedUsersContainer;
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

        public List<string> GetMessagesAsText()
        {
            return _messageContainer.GetMessagesAsText();
        }

        public List<Message> GetMessages()
        {
            return _messageContainer.GetMessages();
        }

        public void AddUserToFollowed(User followed)
        {
            _followedUsersContainer.AddUserToFollowed(followed);
        }

        public List<string> GetWall()
        {
            List<Message> allMessages = new List<Message>();
            allMessages.AddRange(GetMessages());

            var followedUsers = _followedUsersContainer.GetFollowedUsers();

            followedUsers.ForEach(s => allMessages.AddRange(s.GetMessages()));

            OrderMessagesAscending(ref allMessages);

            return allMessages.Select(s => s.GetContentAndStamp()).ToList();
        }

        private void OrderMessagesAscending(ref List<Message> allMessages)
        {
            allMessages = allMessages.OrderByDescending(s => s.GetSecondsSinceCreation()).ToList();
        }
    }
}
