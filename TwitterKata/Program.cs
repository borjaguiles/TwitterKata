using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Twitter twitter = new Twitter(new UserContainer());
            while (true)
            {
                twitter.Run();
            }
        }
    }
}
