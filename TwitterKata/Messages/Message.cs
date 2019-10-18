using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterKata.Messages
{
    public class Message
    {
        private string _content;
        private DateTime _timeStamp;

        public Message(string content)
        {
            _content = content;
            _timeStamp = DateTime.Now;
        }

        public string GetContentAndStamp()
        {
            return _content + " " + GetTimeSinceCreation();
        }

        private string GetTimeSinceCreation()
        {
            var seconds = (long)DateTime.Now.Subtract(_timeStamp).TotalSeconds;
            if (seconds < 60)
            {
                return "(" + seconds.ToString() + " seconds ago)";
            }

            if (seconds < 3600)
            {
                var minutes = seconds / 60;
                return "(" + minutes.ToString() + " minutes ago)";
            }

            if (seconds < 86400)
            {
                var hours = (seconds / 60) / 60;
                return "(" + hours.ToString() + " hours ago)";
            }

            var days = seconds / 60 / 60 / 24;
            return "(" + days.ToString() + " days ago)";
        }
    }
}
