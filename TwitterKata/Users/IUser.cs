using System.Collections.Generic;

namespace TwitterKata
{
    public interface IUser
    {
        void AddMessage(string message);
        bool IsMyName(string name);
        List<string> GetMessages();
    }
}