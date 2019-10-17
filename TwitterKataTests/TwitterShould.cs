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
        public void ShowMessageHellowWorldFromJuanWhenGivenJuan()
        {
            //Assert
            Twitter twitter = new Twitter();
            var output = new StringWriter();
            Console.SetOut(output);
            twitter.Run();

            //Act
            Console.SetIn(new StringReader("Juan"));

            //Assert
            Assert.Equal("Juan -> Hello world!\r\n", output.ToString());

        }
    }
}
