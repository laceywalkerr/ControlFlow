using System;

namespace ControlFlow
{
    class Concitional
    {
        static void Main(string[] args)
        {
            //example
            int age = 12;
            if (age >= 18)
            {
                Console.WriteLine("Can (and should) vote");
            }
            else
            {
                Console.WriteLine("Cannot vote, sorry");
            }
        }
    }
}