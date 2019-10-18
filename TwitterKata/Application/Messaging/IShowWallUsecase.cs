using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterKata.Application.Messaging
{
    public interface IShowWallUseCase
    {
        List<string> ShowWall(string userName);
    }
}
