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
            Console.SetIn(new StringReader("Juan"));

            //Act
            twitter.Run();

            //Assert
            Assert.Equal("Juan -> Hello world!\r\n", output.ToString());

        }

        [Fact]
        public void ShowMessageHappyBirthdayFromAnaWhenGivenAna()
        {
            //Assert
            Twitter twitter = new Twitter();
            var output = new StringWriter();
            Console.SetOut(output);
            Console.SetIn(new StringReader("Ana"));

            //Act
            twitter.Run();

            //Assert
            Assert.Equal("Ana -> Happy birthday!\r\n", output.ToString());

        }
    }
}
