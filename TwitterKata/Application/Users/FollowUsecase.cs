using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterKata.Application.Users
{
    public class FollowUseCase : IFollowUseCase
    {
        private IUserContainer _userContainer;

        public FollowUseCase(IUserContainer userContainer)
        {
            _userContainer = userContainer;
        }

        public void Follow(string user, string followedUser)
        {
            var follower = _userContainer.GetUser(user);
            var followed = _userContainer.GetUser(followedUser);
            follower.AddUserToFollowed(followed);
        }
    }
}
