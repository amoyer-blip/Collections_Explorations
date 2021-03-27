using Collections;
using GetAGremlinRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAGremlin_UI
{
    public class ProgramUI_UI
    {
        //ref repo
        private readonly PersonRepo _pRepo = new PersonRepo();
        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Get-A-Gremlin\n" +
                    "1. View everyone in line\n" +
                    "2. See who is next in line\n" +
                    "3. Distribute Gremlin\n" +
                    "4. Add person to Queue \n" +
                    "5. *Load Grimlin-Dict-Headache*\n" +
                    "25. Close App");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewEveryoneInLine();
                        break;
                    case "2":
                        SeeWhoIsNextInLine();
                        break;
                    case "3":
                        DistributeGremlin();
                        break;
                    case "4":
                        AddPersonToQueue();
                        break;
                    case "5":
                        Load_Grimlin_Dict_Headache();
                        break;
                    case "25":
                        isRunning = false;
                        Console.WriteLine("Thanks");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

            }
        }

        private void Load_Grimlin_Dict_Headache()
        {
            GremlinDict_UI UI = new GremlinDict_UI();
            UI.Run();
        }

        private void AddPersonToQueue()
        {
            Console.Clear();

            Person person = new Person();

            Console.WriteLine("What is your name");
            string userName = Console.ReadLine();
            person.Name = userName;

            Console.WriteLine("How old are you");
            int userAge = int.Parse(Console.ReadLine());
            person.Age = userAge;

            //skip Grelim type 

            _pRepo.AddPersonToQueue(person);
            Console.ReadKey();
        }
        private void DistributeGremlin()
        {

            Console.Clear();

            bool isSuccessful = _pRepo.DistributeGremline();

            if (isSuccessful)
            {
                Console.WriteLine("Gremlin distributed");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            Console.ReadKey();
        }

        private void SeeWhoIsNextInLine()
        {
            Console.Clear();
            Person person = _pRepo.SeeWhoIsNextInLine();
            Console.WriteLine($"Person: {person.Name} {person.Age}");

            Console.ReadKey();
        }

        private void ViewEveryoneInLine()
        {
            Console.Clear();

            Queue<Person> peopleInLine = _pRepo.GetPeopleThatAreInLine();

            foreach (var person in peopleInLine)
            {
                Console.WriteLine($"Person: {person.Name} {person.Age}");
            }

            Console.ReadKey();
        }
        private void Seed()
        {
            Person personA = new Person();
            personA.Age = 20;
            personA.Name = "Gregory";

            var George = new Person
            {
                Name = "George Carlin",
                Age = 60
            };

            _pRepo.AddPersonToQueue(personA);
            _pRepo.AddPersonToQueue(George);

        }
    }
}
