using System;
using System.Collections;

namespace RandomIDGenerator
{
    class Table
    {
        private Hashtable t = null;
        public Table()
        {
            if (t == null)
            {
                t = new Hashtable();
                Console.WriteLine("Hastable created successfully.");
                return;
            }

            Console.WriteLine("Hashtable already exists.");
        }
        public Thing GetThing(String id)
        {
            var thing = new Thing(id);

            return thing;
        }

        public Hashtable GetTable()
        {
            return t;
        }

        public void AddThing()
        {
            String id = GenerateID.generateUniqueID();
            while (t.ContainsKey(id) && t.Count < GenerateID.GetMaxEntries())
            {
                id = GenerateID.generateUniqueID();
                
            }
            var thing = new Thing(id);
            Console.WriteLine("ID: " + thing.GetID());
            t.Add(thing.GetID(), thing);
        }

        public void PrintAllThings()
        {
            Console.Clear();
            var keys = t.Keys;
            if (keys.Count == 0)
            {
                Console.WriteLine("Table has no entries");
            }
            foreach (var k in keys)
            {
                // must cast to object type first
                Thing t = (Thing)this.t[k];
                Console.WriteLine("Thing ID: " + t.GetID());
            }
            
        }

        public void EmptyTable()
        {
            t.Clear();
            Console.WriteLine("Table cleared.");
        }
    }
}