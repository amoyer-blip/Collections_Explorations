using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Gremlin
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsNaughty { get; set; }

        public Gremlin()
        {
            Name = "Kruger";
            IsNaughty = true;
        }
        public Gremlin(string name, bool isNaughty)
        {
            Name = name;
            IsNaughty = isNaughty;
        }
    }
}
