using System;
using System.Collections.Generic;
using System.Linq;
using TwitterKata.Messages;

namespace TwitterKata
{
    public class UserContainer : IUserContainer
    {
        private readonly List<User> _userList = new List<User>();

        public User GetUser(string name)
        {
            return _userList.Find(s => s.IsMyName(name));
        }

        public User AddNewUser(string name)
        {
            var user = new User();
            user.SetName(name);
            _userList.Add(user);
            return user;
        }
    }
}