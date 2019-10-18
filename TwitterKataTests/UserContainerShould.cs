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
            var resultFirst = userContainer.GetUser("Felipe"); 
            var resultSec = userContainer.GetUser("Juan");
            var resultThird = userContainer.GetUser("Carlos");

            //Assert
            Assert.True(resultFirst.IsMyName("Felipe"));
            Assert.True(resultSec.IsMyName("Juan"));
            Assert.True(resultThird.IsMyName("Carlos"));
        }
    }
}
