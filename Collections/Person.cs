using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gremlin Gremlin { get; set; }

        public Person()
        {

        }

        public Person(string name, int age, Gremlin gremlin)
        {
            Name = name;
            Age = age;
            Gremlin = gremlin;
        }
    }
}
