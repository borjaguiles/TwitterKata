using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitterKata
{
    public class Twitter
    {
        private readonly UserContainer _userContainer = new UserContainer();

        public void Run()
        {
            var command = Console.ReadLine().Split(" ");

            var action = GetActionFromCommand(command);
            var name = GetNameFromCommand(command);
            var user = _userContainer.GetUser(name);

            if (user == null)
            {
                user = _userContainer.AddNewUser(name);
            }

            if (action == TwitterActions.PostMessage)
            {
                PostMessage(command, user);
            }

            if (action == TwitterActions.ShowUserMessages)
            {
                ShowUserMessages(user);
            }
        }

        private static void ShowUserMessages(User user)
        {
            user.GetMessages().ForEach(Console.WriteLine);
        }

        private static void PostMessage(string[] command, User user)
        {
            string message = string.Join(' ', command.Skip(2));
            user.AddMessage(message);
        }

        private static string GetNameFromCommand(string[] command)
        {
            return command[0];
        }

        private TwitterActions GetActionFromCommand(string[] command)
        {
            var stringAction = command.Length > 1 ? command[1] : null;
            if (stringAction == "->")
            {
                return TwitterActions.PostMessage;
            }
            if (stringAction == null)
            {
                return TwitterActions.ShowUserMessages;
            }

            return TwitterActions.Unknown;
        }
    }
}
