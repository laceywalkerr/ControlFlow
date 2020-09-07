using System;

namespace ControlFlow
{
    class ForEachLoop
    {
        static void Main(string[] args)
        {
            //example
            List<Person> people = data.GetAllPeople();
            foreach (Person p in people)
            {
                Console.WriteLine($"Hi, {p.FirstName} {p.LastName}!");
            }
        }
    }
}