using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterKata.Application.Messaging
{
    class ShowWallUseCase : IShowWallUseCase
    {
        private IUserContainer _userContainer;

        public ShowWallUseCase(IUserContainer userContainer)
        {
            _userContainer = userContainer;
        }

        public List<string> ShowWall(string userName)
        {
            var user = _userContainer.GetUser(userName);
            var messages = user.GetWall();
            return messages;
        }
    }
}
