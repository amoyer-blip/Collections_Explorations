using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAGremlinRepository
{
    public class PersonRepo
    {
        //We want to make a fake database based on A Queue...
        private readonly Queue<Person> _personDatabase = new Queue<Person>();

        public bool AddPersonToQueue(Person person)
        {
            _personDatabase.Enqueue(person);
            return true;
        }

        public Queue<Person> GetPeopleThatAreInLine()
        {
        return _personDatabase;
        }

        public Person SeeWhoIsNextInLine()
        {
            return _personDatabase.Peek();
        }

        public bool DistributeGremline()
        {
            Person personInLine = SeeWhoIsNextInLine();
            if (personInLine == null)
            {
                return false;
            }
            else
            {
                personInLine.Gremlin = new Gremlin();
                _personDatabase.Dequeue();
                return true;

            }
        }
    }
}
