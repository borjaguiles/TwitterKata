using System.Collections.Generic;

namespace TwitterKata.Messages
{
    public interface IMessageContainer
    {
        void AddMessage(string message);
        List<string> GetMessagesAsText();
    }
}