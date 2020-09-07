using System;

namespace ControlFlow
{
    class WhileLoop
    {
        static void Main(string[] args)
        {
            //example
            Console.Write("Should we continue? (y/n) ");
            string input = Console.ReadLine();

            while (input == "y")
            {
                Console.WriteLine("We're continuing!");
                Console.Write("Should we continue? (y/n) ");
                input = Console.ReadLine();
            }
        }
    }
}