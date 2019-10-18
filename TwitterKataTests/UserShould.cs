using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using TwitterKata;
using TwitterKata.Messages;
using Xunit;

namespace TwitterKataTests
{
    public class UserShould
    {
        [Fact]
        public void BeAbleToSetHisNameAndThenCheckItAfterwards()
        {
            //Assemble
            User _user = new User();
            _user.SetName("Juan");

            //Act
            var result = _user.IsMyName("Juan");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddANewMessageAndThenShowIt()
        {
            Mock<IMessageContainer> _messageContainer = new Mock<IMessageContainer>();
            _messageContainer.Setup(s => s.GetMessagesAsText()).Returns(new List<string>() {"Hola"});
            User user = new User();
            user.AddMessage("Hola");

            //Act
            var result = user.GetMessages();

            //Assert
            Assert.Equal("Hola (0 seconds ago)", result.First());
        }

        [Fact]
        public void AddManyMessagesAndPrintThemAll()
        {
            Mock<IMessageContainer> _messageContainer = new Mock<IMessageContainer>();
            _messageContainer.Setup(s => s.GetMessagesAsText()).Returns(new List<string>() { "Hola" });
            User user = new User();
            user.AddMessage("Hola");
            user.AddMessage("Que tal?");
            user.AddMessage("Despierto?");

            //Act
            var result = user.GetMessages();

            //Assert
            Assert.Equal("Hola (0 seconds ago) " + "Que tal? (0 seconds ago) " + "Despierto? (0 seconds ago)", String.Join(' ',result));
        }
    }
}
