using System;
using System.Collections.Generic;

namespace TwitterKata
{
    public class ShowMessagesUseCase : IShowMessagesUseCase
    {
        private IUserContainer _userContainer;
        public ShowMessagesUseCase(IUserContainer userContainer)
        {
            _userContainer = userContainer;
        }

        public List<string> ShowUserMessages(string userName)
        {
            var user = _userContainer.GetUser(userName);

            if (user == null)
            {
                return new List<string>();
            }

            return user.GetMessages();
        }
    }
}