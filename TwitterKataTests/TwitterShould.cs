using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit;

namespace TwitterKataTests
{
    public class TwitterShould
    {
        [Fact]
        public void ShowAMessageWhenJuanWritesAMessage()
        {
            //Assert
            Twitter twitter = new Twitter();

            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("Juan -> Hello world!");
            twitter.Run();
            //Act
            Console.SetIn(input);
            
            

            //Assert
            Assert.Equal("Juan -> Hello world!", output.ToString);

        }
    }
}
