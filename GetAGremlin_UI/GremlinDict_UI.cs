using Collections;
using GetAGremlinRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAGremlin_UI
{
    public class GremlinDict_UI
    {
        //We need to reference the GremlinRepo
        private readonly GremlinRepo _gRepo = new GremlinRepo();


        public void Run()
        {
            // Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Gremlin-Dictionary-Headache\n" +
                    "1. Add Gremlin\n" +
                    "2. View All Gremlins\n" +
                    "3. View Gremlin By Key\n" +
                    "4. Update Gremlin By Key\n" +
                    "5. Delete Gremlin By Key\n" +
                    "25.Back to Get-A-Gremlin");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddGremlin();
                        break;
                    case "2":
                        ViewAllGremlins();
                        break;
                    case "3":
                        ViewGremlinByKey();
                        break;
                    case "4":
                        UpdateGremlinByKey();
                        break;
                    case "5":
                        DeleteGremlinByKey();

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


        private void DeleteGremlinByKey()
        {
            Console.Clear();
            //getting gremlin key....
            Console.WriteLine("Input Gremlin by key");
            int userInputGremlinKey = int.Parse(Console.ReadLine());

            var isSuccessful = _gRepo.DeleteGremlin(userInputGremlinKey);

            if (isSuccessful)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("FAILED");
            }

            Console.ReadKey();

        }


        private void UpdateGremlinByKey()
        {
            Console.Clear();

            //getting gremlin key....
            Console.WriteLine("Input Gremlin by key");
            int userInputGremlinKey = int.Parse(Console.ReadLine());

            //create new Gremlin data....
            Gremlin newGremlinData = new Gremlin();

            Console.WriteLine("Please enter a name");
            string userInputName = Console.ReadLine();
            newGremlinData.Name = userInputName;

            Console.WriteLine("Is gremlin naughty?(y/n)");
            string userInputIsNaughty = Console.ReadLine().ToLower();

            if (userInputIsNaughty == "y")
            {
                newGremlinData.IsNaughty = true;
            }
            else
            {
                newGremlinData.IsNaughty = false;
            }

            var isSuccessful = _gRepo.UpdateGremlin(userInputGremlinKey, newGremlinData);

            if (isSuccessful)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("FAILED");
            }

            Console.ReadKey();
        }

      

    

        private void ViewGremlinByKey() 
        {
            Console.Clear();
            Console.WriteLine("Input Gremlin by key");
            int userInputGremlinKey = int.Parse(Console.ReadLine());

            Gremlin gremlin = _gRepo.GetGremlinByKey(userInputGremlinKey);

            if (gremlin == null)
            {
                Console.WriteLine("Does not exist");
            }
            else
            {
                Console.WriteLine($"{gremlin.ID}\n" +
                    $"{gremlin.Name}\n" +
                    $"{gremlin.IsNaughty}\n");
            }

            Console.ReadKey();
        }
        private void ViewAllGremlins()
        {
            Console.Clear();
            
          

            foreach (var gremlin in _gRepo.GetGremlins())
            {
                Console.WriteLine($"GremlinDictId: {gremlin.Key}\n" +
                    $"GremlinId: {gremlin.Value.ID}\n" +
                    $"GremlinName: {gremlin.Value.Name}\n" +
                    $"IsNaughty: {gremlin.Value.IsNaughty}\n");

            }


            Console.ReadKey();
        }

        private void AddGremlin()
        {
            Console.Clear();

            Gremlin gremlin = new Gremlin();

            Console.WriteLine("Please enter a name");
            string userInputName = Console.ReadLine();
            gremlin.Name = userInputName;

            Console.WriteLine("Is gremlin naughty?(y/n)");
            string userInputIsNaughty = Console.ReadLine().ToLower();

            if (userInputIsNaughty == "y")
            {
                gremlin.IsNaughty = true;
            }
            else
            {
                gremlin.IsNaughty = false;
            }

            bool isSuccessful = _gRepo.AddGremlinToDataBase(gremlin);

            if (isSuccessful)
            {
                Console.WriteLine("Created");
            }
            else
            {
                Console.WriteLine("Failed");
            }
            Console.ReadKey();
        }
        private void Seed()
        {
            throw new NotImplementedException();
        }
    }
}





