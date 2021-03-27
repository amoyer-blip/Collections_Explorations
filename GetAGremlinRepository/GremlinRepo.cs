using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAGremlinRepository
{
    public class GremlinRepo
    {
        //Make a fake database based on dictionary
        private readonly Dictionary<int, Gremlin> _gremlinDatabase = new Dictionary<int, Gremlin>();

        int _Count = 0;

        public bool AddGremlinToDataBase(Gremlin gremlin)
        {
            _Count++;
            gremlin.ID = _Count;
            _gremlinDatabase.Add(_Count, gremlin);
            return true;
        }

        public Dictionary<int,Gremlin> GetGremlins()
        {
            return _gremlinDatabase;
        }

        public Gremlin GetGremlinByKey(int key)
        {
            foreach (var gremlin in _gremlinDatabase)
            {
                if (gremlin.Key==key)
                {
                    return gremlin.Value;
                }
            }
            return null;
        }

        public bool UpdateGremlin(int oldGrim, Gremlin newGremlinData)
        {
            //used method above to pull this off
            Gremlin oldGremlin = GetGremlinByKey(oldGrim);
            if (oldGremlin ==null)
            {
                return false;
            }
            else
            {
                oldGremlin.Name = newGremlinData.Name;
                oldGremlin.IsNaughty = newGremlinData.IsNaughty;
                return true;
            }
           
          
        }

        public bool DeleteGremlin(int key)
        {
            foreach (var g in _gremlinDatabase)
            {
                if (g.Key==key)
                {
                    _gremlinDatabase.Remove(g.Key);
                    return true;
                }
            }

            return false;
        }
    }
}
