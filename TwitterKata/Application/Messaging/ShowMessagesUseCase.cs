using System;

namespace TwitterKata
{
    public class ShowMessagesUseCase : IShowMessagesUseCase
    {
        private IUserContainer _userContainer;
        public ShowMessagesUseCase(IUserContainer userContainer)
        {
            _userContainer = userContainer;
        }

        public void ShowUserMessages(string userName)
        {
            var user = _userContainer.GetUser(userName);

            if (user == null)
            {
                return;
            }

            user.GetMessages().ForEach(Console.WriteLine);
        }
    }
}