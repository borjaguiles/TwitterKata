using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitterKata
{
    public class Twitter
    {
        private readonly List<string> comment = new List<string>();
        public void Run()
        {
            var command = Console.ReadLine().Split(" ");

            var action = command.Length > 1 ? command[1] : null;

            if (action == "->")
            {
                comment.Add(string.Join(' ',command.Skip(2)));
            }

            if (action == null)
            {
                comment.ForEach(Console.WriteLine);
            }
        }
    }
}
