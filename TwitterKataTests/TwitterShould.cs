using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using TwitterKata;
using Xunit;

namespace TwitterKataTests
{
    public class TwitterShould
    {
        private Twitter twitter;
        private StringWriter output;
        private UserContainer _userContainer;
        public TwitterShould()
        {
            _userContainer = new UserContainer();

            twitter = new Twitter(new PostMessageUseCase(_userContainer), new ShowMessagesUseCase(_userContainer));
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
        [InlineData("Hello world! (0 seconds ago)", "Juan", "Juan -> Hello world!")]
        [InlineData("Happy birthday! (0 seconds ago)", "Ana", "Ana -> Happy birthday!")]
        [InlineData("New album today (0 seconds ago)", "Oscar", "Oscar -> New album today")]
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
            string expected = "Vaya mañanita! (0 seconds ago)" + "\r\n" + "Hoy birras! (0 seconds ago)" + "\r\n" + "Vaya resaca! (0 seconds ago)" + "\r\n" +
                              "Los domingos me suelo jurar... (0 seconds ago)" + "\r\n";
            //Act
            twitter.Run();

            //Assert
            Assert.Equal(expected, output.ToString());
        }

        [Fact]
        public void ShowMessagesFromAnyUserGivenItsName()
        {
            //Assert
            string expected = "Hola (0 seconds ago)" + "\r\n" + "Adios (0 seconds ago)" + "\r\n" + "Que tal? (0 seconds ago)" + "\r\n" + "Gracias (0 seconds ago)" + "\r\n";
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

        [Fact]
        public void ShowTheTimePassedSinceTheMessageWasPostedWhenViewingAUserMessages()
        {
            //Assert
            string expected = "Hola (1 seconds ago)" + "\r\n" ;
            Console.SetIn(new StringReader("Juan -> Hola"));
            twitter.Run();
            Thread.Sleep(1000);
            Console.SetIn(new StringReader("Juan"));
            twitter.Run();

            //Assert
            Assert.Equal(expected, output.ToString());
        }
    }
}
