using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterKata.Messages;
using Xunit;

namespace TwitterKataTests
{
    public class MessageContainerShould
    {
        [Fact]
        public void AddAMessageAndReturnIt()
        {
            MessageContainer messageContainter = new MessageContainer();
            messageContainter.AddMessage("Hola");

            //Act
            var result = messageContainter.GetMessagesAsText();

            //Assert
            Assert.Equal("Hola (0 seconds ago)", result.First());
        }

        [Fact]
        public void AddManyMessagesAndShowThem()
        {
            MessageContainer messageContainter = new MessageContainer();
            messageContainter.AddMessage("Hola");
            messageContainter.AddMessage("Pepe");
            messageContainter.AddMessage("Col");

            //Act
            var result = messageContainter.GetMessagesAsText();

            //Assert
            Assert.Equal("Hola (0 seconds ago) Pepe (0 seconds ago) Col (0 seconds ago)", String.Join(' ',result));
        }
    }
}
