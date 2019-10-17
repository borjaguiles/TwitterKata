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
        public void ShowAllMessagesFromAUserGivenHisName()
        {
            //Assert
            Console.SetIn(new StringReader("Vicen -> Vaya mañanita!"));
            twitter.Run();
            Console.SetIn(new StringReader("Vicen -> Hoy birras!"));
            twitter.Run();
            Console.SetIn(new StringReader("Vicen -> Vaya resaca!"));
            twitter.Run();
            Console.SetIn(new StringReader("Vicen -> Los domingos me suelo jurar..."));
            twitter.Run();
            Console.SetIn(new StringReader("Vicen"));
            string expected = "Vaya mañanita!" + "\r\n" + "Hoy birras!" + "\r\n" + "Vaya resaca!" + "\r\n" +
                              "Los domingos me suelo jurar..." + "\r\n";
            //Act
            twitter.Run();

            //Assert
            Assert.Equal(expected, output.ToString());
        }

        [Fact]
        public void ShowMessagesFromAnyUserGivenItsName()
        {
            //Assert
            string expected = "Hola" + "\r\n" + "Adios" + "\r\n" + "Que tal?" + "\r\n" + "Gracias" + "\r\n";
            Console.SetIn(new StringReader("Juan -> Hola"));
            twitter.Run();
            Console.SetIn(new StringReader("Ana -> Adios"));
            twitter.Run();
            Console.SetIn(new StringReader("Lucas -> Que tal?"));
            twitter.Run();
            Console.SetIn(new StringReader("Maite -> Gracias"));
            twitter.Run();
            //Act
            Console.SetIn(new StringReader("Juan"));
            twitter.Run();
            Console.SetIn(new StringReader("Ana"));
            twitter.Run();
            Console.SetIn(new StringReader("Lucas"));
            twitter.Run();
            Console.SetIn(new StringReader("Maite"));
            twitter.Run();

            //Assert
            Assert.Equal(expected, output.ToString());
        }
    }
}
