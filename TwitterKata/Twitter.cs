using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitterKata
{
    public class Twitter
    {
        private readonly Dictionary<string,List<string>> _comment = new Dictionary<string, List<string>>();
        public void Run()
        {
            var command = Console.ReadLine().Split(" ");

            var action = command.Length > 1 ? command[1] : null;
            var name = command[0];
            if (action == "->")
            {
                if (_comment.ContainsKey(name))
                {
                    _comment[name].Add(string.Join(' ', command.Skip(2)));
                }
                else
                {
                    _comment.Add(name, new List<string>() { string.Join(' ', command.Skip(2)) });
                }
            }

            if (action == null)
            {
                if (_comment.ContainsKey(name))
                {
                    _comment[name].ForEach(Console.WriteLine);
                }
            }
        }
    }
}
