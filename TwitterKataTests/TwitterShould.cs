using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using TwitterKata;
using Xunit;

namespace TwitterKataTests
{
    public class TwitterShould
    {
        private Twitter twitter;
        private StringWriter output;
        public TwitterShould()
        {
            twitter = new Twitter();
            output = new StringWriter();
            Console.SetOut(output);
        }
        [Fact]
        public void ShowNothingWhenGivenCarlos()
        {
            //Assert
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
            Console.SetIn(new StringReader("Juan -> Hello world!"));
            twitter.Run();
            Console.SetIn(new StringReader("Juan"));
            //Act
            twitter.Run();

            //Assert
            Assert.Equal("Hello world!" + "\r\n", output.ToString());

        }

        [Fact]
        public void ShowMessageHappyBirthdayFromAnaWhenGivenAna()
        {
            //Assert
            Console.SetIn(new StringReader("Ana -> Happy birthday!"));
            twitter.Run();
            Console.SetIn(new StringReader("Ana"));
            //Act
            twitter.Run();

            //Assert
            Assert.Equal("Happy birthday!" + "\r\n", output.ToString());

        }

        [Theory]
        [InlineData("Hello world!", "Juan", "Juan -> Hello world!")]
        [InlineData("Happy birthday!", "Ana", "Ana -> Happy birthday!")]
        [InlineData("New album today", "Oscar", "Oscar -> New album today")]
        public void ShowTheMessagesGivenByPeopleWhenInputtingTheirNames(string expected, string name, string post)
        {
            //Assert
            Console.SetIn(new StringReader(post));
            twitter.Run();
            Console.SetIn(new StringReader(name));

            //Act
            twitter.Run();

            //Assert
            Assert.Equal(expected + "\r\n", output.ToString());

        }

        [Fact]
        public void ShowTwoMessagesFromAUserGivenHisName()
        {
            //Assert
            Console.SetIn(new StringReader("Vicen -> Vaya mañanita!"));
            twitter.Run();
            Console.SetIn(new StringReader("Vicen -> Hoy birras!"));
            twitter.Run();
            Console.SetIn(new StringReader("Vicen"));
            string expected = "Vaya mañanita!" + "\r\n" + "Hoy birras!" + "\r\n";
            //Act
            twitter.Run();

            //Assert
            Assert.Equal(expected, output.ToString());
        }
    }
}
