using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterKata.Application.Users
{
    class FollowedUsersContainer : IFollowedUsersContainer
    {
        private List<User> _followedUsers;

        public FollowedUsersContainer()
        {
            _followedUsers = new List<User>();
        }

        public void AddUserToFollowed(User user)
        {
            _followedUsers.Add(user);
        }

        public List<User> GetFollowedUsers()
        {
            return _followedUsers;
        }
    }
}
