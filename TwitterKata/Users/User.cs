using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterKata
{
    public class User : IUser
    {
        private string Name;
        private List<string> Messages;

        public User(string name)
        {
            Name = name;
            Messages = new List<string>();
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        public bool IsMyName(string name)
        {
            return Name == name;
        }

        public List<string> GetMessages()
        {
            return Messages;
        }
    }
}
