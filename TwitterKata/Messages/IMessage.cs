﻿namespace TwitterKata.Messages
{
    public interface IMessage
    {
        string GetContentAndStamp();
        string GetTimeSinceCreation();
    }
}