using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Explorations
{
    class Program
    {
        static void Main(string[] args)
        {
            //These are some collections...

            Console.WriteLine("This is a List");
            //List                                  shorthand way 
            List<int> grpNumbers = new List<int>() { 5, 7, 10, 11, 70 };

            //Add longhand 
            grpNumbers.Add(2);
            grpNumbers.Add(8);
            grpNumbers.Add(7);
            grpNumbers.Add(3);
            grpNumbers.Add(1);
            grpNumbers.Add(0);

            for (int i = 0; i < grpNumbers.Count; i++)
            {
                Console.WriteLine(grpNumbers[i]);
            }
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("This is a queue");
            Console.WriteLine("FIFO -> First in, first out");

            Queue<Person> peopleInLine = new Queue<Person>();

            Person personA = new Person();
            personA.Age = 20;
            personA.Name = "Gregory";

            var George = new Person
            {
                Name = "George Carlin",
                Age = 60
            };

            //1st in line
            peopleInLine.Enqueue(new Person { Name = "Jake", Age = 10 });
            peopleInLine.Enqueue(personA);

            //2nd in line
            peopleInLine.Enqueue(personA);

            //3rd in line
            peopleInLine.Enqueue(George);

            //look at everyone in line
            Console.WriteLine("Everyone just got in the line...");

            foreach (var person in peopleInLine)
            {
                Console.WriteLine($"Person {person.Name} {person.Age}\n" +
                $"----------------------------------------\n");
            }

            Console.WriteLine("People are starting to leave...");

            peopleInLine.Dequeue();
            peopleInLine.Dequeue();

            foreach (var person in peopleInLine)
            {
                Console.WriteLine($"Person {person.Name} {person.Age}\n" +
                    $"--------------------------------------------\n");
            }

            Console.WriteLine("------------------------------------------------------");

            Dictionary<int, Gremlin> gremlinsDict = new Dictionary<int, Gremlin>();


            //WE CANNOT HAVE THE SAME KEY
            //longhand
            gremlinsDict.Add(1, new Gremlin { Name = "Gizmo", IsNaughty = false });
            gremlinsDict.Add(2, new Gremlin { Name = "Vader", IsNaughty = true });
            gremlinsDict.Add(3, new Gremlin { Name = "Kruger", IsNaughty = true });
            gremlinsDict.Add(4, new Gremlin { Name = "Fred", IsNaughty = true });

            foreach (var gremlin in gremlinsDict)
            {
                Console.WriteLine(gremlin);
            }

            Console.WriteLine("------------------------------------------------------");
            //Look only at keys
            foreach (var gremlin in gremlinsDict.Keys)
            {
                Console.WriteLine(gremlin);
            }

            Console.WriteLine("------------------------------------------------------");
            //Look only at values
            foreach (var gremlin in gremlinsDict.Values)
            {
                Console.WriteLine($"{gremlin.Name} {gremlin.IsNaughty}");
            }
            
            Console.WriteLine("------------------------------------------------------");
            foreach (var gremlin in gremlinsDict)
            {
                Console.WriteLine(gremlin.Key);
                Console.WriteLine($"{gremlin.Value.Name} {gremlin.Value.IsNaughty}");
            }

            foreach (var gremlin in gremlinsDict)
            {
                if (gremlin.Key == 3)
                {
                    Console.WriteLine($"{gremlin.Value.Name} {gremlin.Value.IsNaughty}"); 
                }
                
                else if (gremlin.Value.Name == "Gizmo")
                {
                    Console.WriteLine(gremlin.Key);
                }

            }

            Console.ReadKey();
        }
    }
}



