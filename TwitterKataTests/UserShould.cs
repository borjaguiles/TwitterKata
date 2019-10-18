using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Assert.Equal("Hola (0 seconds ago)", result.First().GetContentAndStamp());
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
            var result = user.GetMessages().Select(s => s.GetContentAndStamp()).ToList();

            //Assert
            Assert.Equal("Hola (0 seconds ago) " + "Que tal? (0 seconds ago) " + "Despierto? (0 seconds ago)", String.Join(' ',result));
        }

        [Fact]
        public void AddAUserToFollowedUsersAndShowYourMessagesAndItsMessages()
        {
            //Assemble
            User userJuan = new User();
            userJuan.SetName("Juan");
            User userAlicia = new User();
            userAlicia.SetName("Alicia");
            userAlicia.AddMessage("Hello");
            userJuan.AddMessage("You online?");
            userAlicia.AddMessage("How are you?");
            userJuan.AddMessage("Ready to hunt some orcs!");
            userJuan.AddMessage("You with me?");
            userJuan.AddUserToFollowed(userAlicia);

            //Act
            var result = userJuan.GetWall();

            //Assert
            Assert.Equal(5, result.Count);
            Assert.Equal("Hello (0 seconds ago)", result.First());
            
        }
    }
}
