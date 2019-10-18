using System.Collections.Generic;

namespace TwitterKata
{
    public interface IShowMessagesUseCase
    {
        List<string> ShowUserMessages(string userName);
    }
}