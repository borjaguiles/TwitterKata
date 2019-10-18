using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TwitterKata.Messages;
using Xunit;

namespace TwitterKataTests
{
    public class MessageShould
    {
        [Fact]
        public void SaveAMessageAndShowItWithTheTimeSinceCreation()
        {
            Message message = new Message("Hola");
            Thread.Sleep(2000);
            //Act
            var result = message.GetContentAndStamp();

            //Assert
            Assert.Equal("Hola (2 seconds ago)", result);
        }
    }
}
