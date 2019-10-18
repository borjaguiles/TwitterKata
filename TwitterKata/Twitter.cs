using System;
using System.Collections.Generic;
using System.Linq;
using TwitterKata.Application.Messaging;
using TwitterKata.Application.Users;

namespace TwitterKata
{
    public class Twitter
    {
        private readonly IPostMessageUseCase _postMessageUseCase;
        private readonly IShowMessagesUseCase _showMessagesUseCase;
        private IFollowUseCase _followUseCase;
        private IShowWallUseCase _showWallUseCase;

        public Twitter( IPostMessageUseCase postMessageUseCase, IShowMessagesUseCase showMessagesUseCase, IFollowUseCase followUseCase, IShowWallUseCase showWallUseCase)
        {
            _postMessageUseCase = postMessageUseCase;
            _showMessagesUseCase = showMessagesUseCase;
            _followUseCase = followUseCase;
            _showWallUseCase = showWallUseCase;
        }

        public void Run()
        {
            var command = Console.ReadLine().Split(" ");

            var action = GetActionFromCommand(command);
            var userName = GetNameFromCommand(command);


            if (action == TwitterActions.PostMessage)
            {
                var message = GetMessageFromCommand(command);
                _postMessageUseCase.PostMessage(message, userName);
            }

            if (action == TwitterActions.ShowUserMessages)
            {
                var messages = _showMessagesUseCase.ShowUserMessages(userName);
                PrintMessages(messages);
            }

            if (action == TwitterActions.Follow)
            {
                var followedUser = command[2];
                _followUseCase.Follow(userName, followedUser);
            }

            if (action == TwitterActions.ShowUserWall)
            {
                var messages = _showWallUseCase.ShowWall(userName);
                PrintMessages(messages);
            }
        }

        private void PrintMessages(List<string> messages)
        {
            messages.ForEach(Console.WriteLine);
        }

        private string GetMessageFromCommand(string[] command)
        {
            return string.Join(' ', command.Skip(2));
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

            if (stringAction == "follow")
            {
                return TwitterActions.Follow;
            }

            if (stringAction == "wall")
            {
                return TwitterActions.ShowUserWall;
            }

            return TwitterActions.Unknown;
        }
    }
}
