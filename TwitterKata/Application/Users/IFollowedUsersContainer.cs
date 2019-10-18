using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterKata.Application.Users
{
    public interface IFollowedUsersContainer
    {
        void AddUserToFollowed(User user);
        List<User> GetFollowedUsers();
    }
}
