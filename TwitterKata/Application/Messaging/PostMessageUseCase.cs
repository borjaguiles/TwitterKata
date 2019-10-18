using System.Linq;

namespace TwitterKata
{
    public class PostMessageUseCase : IPostMessageUseCase
    {
        private IUserContainer _userContainer;
        public PostMessageUseCase(IUserContainer userContainer)
        {
            _userContainer = userContainer;
        }

        public void PostMessage(string message, string userName)
        {
            var user = _userContainer.GetUser(userName);

            if (user == null)
            {
                user = _userContainer.AddNewUser(userName);
            }

            user.AddMessage(message);
        }
    }
}