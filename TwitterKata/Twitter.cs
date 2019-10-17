using System;

namespace TwitterKata
{
    public class Twitter
    {
        public void Run()
        {
            var name = Console.ReadLine();

            if (name == "Ana")
            {
                Console.WriteLine("Ana -> Happy birthday!");
            }

            if (name == "Juan")
            {
                Console.WriteLine("Juan -> Hello world!");
            }
        }
    }
}
