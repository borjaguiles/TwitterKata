using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using TwitterKata;
using Xunit;

namespace TwitterKataTests
{
    public class TwitterShould
    {
        [Fact]
        public void ShowNothingWhenGivenCarlos()
        {
            //Assert
            Twitter twitter = new Twitter();
            var output = new StringWriter();
            Console.SetOut(output);
            Console.SetIn(new StringReader("Carlos"));

            //Act
            twitter.Run();

            //Assert
            Assert.Equal("", output.ToString());

        }

        [Fact]
        public void ShowMessageHelloWorldFromJuanWhenGivenJuan()
        {
            //Assert
            Twitter twitter = new Twitter();
            var output = new StringWriter();
            Console.SetOut(output);
            Console.SetIn(new StringReader("Juan -> Hello world!"));
            twitter.Run();
            Console.SetIn(new StringReader("Juan"));
            //Act
            twitter.Run();

            //Assert
            Assert.Equal("Hello world!", output.ToString());

        }

        [Fact]
        public void ShowMessageHappyBirthdayFromAnaWhenGivenAna()
        {
            //Assert
            Twitter twitter = new Twitter();
            var output = new StringWriter();
            Console.SetOut(output);
            Console.SetIn(new StringReader("Ana -> Happy birthday!"));
            twitter.Run();
            Console.SetIn(new StringReader("Ana"));
            //Act
            twitter.Run();

            //Assert
            Assert.Equal("Happy birthday!", output.ToString());

        }

        [Theory]
        [InlineData("Hello world!", "Juan", "Juan -> Hello world!")]
        [InlineData("Happy birthday!", "Ana", "Ana -> Happy birthday!")]
        [InlineData("New album today", "Oscar", "Oscar -> New album today")]
        public void ShowTheMessagesGivenByPeopleWhenInputtingTheirNames(string expected, string name, string post)
        {
            //Assert
            Twitter twitter = new Twitter();
            var output = new StringWriter();
            Console.SetOut(output);
            Console.SetIn(new StringReader(post));
            twitter.Run();
            Console.SetIn(new StringReader(name));

            //Act
            twitter.Run();

            //Assert
            Assert.Equal(expected, output.ToString());

        }
    }
}
