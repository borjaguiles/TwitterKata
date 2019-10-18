using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterKata
{
    class Program
    {
        static void Main(string[] args)
        {
            UserContainer userContainer = new UserContainer();
            Twitter twitter = new Twitter(new PostMessageUseCase(userContainer), new ShowMessagesUseCase(userContainer));
            while (true)
            {
                twitter.Run();
            }
        }
    }
}
