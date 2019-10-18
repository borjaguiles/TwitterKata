using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterKata.Application.Users
{
    public interface IFollowUseCase
    {
        void Follow(string user, string followedUser);
    }
}
