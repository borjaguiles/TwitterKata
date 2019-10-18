using System;
using System.Collections.Generic;
using System.Text;
using TwitterKata;
using TwitterKata.Messages;
using Xunit;

namespace TwitterKataTests
{
    public class UserContainerShould
    {
        [Fact]
        public void SaveUserJuanAndThenReturnItWhenAskedForItByName()
        {
            //Assemble
            UserContainer userContainer = new UserContainer();
            userContainer.AddNewUser("Juan");
            var expectedUser = new User();
            expectedUser.SetName("Juan");

            //Act
            var result = userContainer.GetUser("Juan");

            //Assert
            Assert.Equal(expectedUser.IsMyName("Juan"), result.IsMyName("Juan"));
        }

        [Fact]
        public void SaveThreeUsersThenReturnThemInARandomOrderByName()
        {
            //Assemble
            UserContainer userContainer = new UserContainer();
            userContainer.AddNewUser("Juan");
            userContainer.AddNewUser("Carlos");
            userContainer.AddNewUser("Felipe");

            //Act
            var resultFirst = userContainer.GetUser("Juan");
            var resultSec = userContainer.GetUser("Carlos");
            var resultThird = userContainer.GetUser("Felipe");

            //Assert
            Assert.True(resultFirst.IsMyName("Juan"));
            Assert.True(resultSec.IsMyName("Carlos"));
            Assert.True(resultThird.IsMyName("Felipe"));
        }
    }
}
