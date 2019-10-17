using System;
using System.Linq;

namespace TwitterKata
{
    public class Twitter
    {
        private string comment;
        public void Run()
        {
            var command = Console.ReadLine().Split(" ");

            var action = command.Length > 1 ? command[1] : null;

            if (action == "->")
            {
                comment = string.Join(' ',command.Skip(2));
            }

            if (action == null)
            {
                Console.Write(comment);
            }
        }
    }
}
