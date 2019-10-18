using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitterKata
{
    public class Twitter
    {
        private readonly IPostMessageUseCase _postMessageUseCase;
        private readonly IShowMessagesUseCase _showMessagesUseCase;

        public Twitter( IPostMessageUseCase postMessageUseCase, IShowMessagesUseCase showMessagesUseCase)
        {
            _postMessageUseCase = postMessageUseCase;
            _showMessagesUseCase = showMessagesUseCase;
        }

        public void Run()
        {
            var command = Console.ReadLine().Split(" ");

            var action = GetActionFromCommand(command);
            var name = GetNameFromCommand(command);


            if (action == TwitterActions.PostMessage)
            {
                var message = string.Join(' ', command.Skip(2));
                _postMessageUseCase.PostMessage(message, name);
            }

            if (action == TwitterActions.ShowUserMessages)
            {
                _showMessagesUseCase.ShowUserMessages(name);
            }
        }

        private string GetNameFromCommand(string[] command)
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
