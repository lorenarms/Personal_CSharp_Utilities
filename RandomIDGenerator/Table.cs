﻿using System;
using System.Collections;

namespace RandomIDGenerator
{
    internal class Table
    {
        private readonly Hashtable _t = null;
        public Table()
        {
            if (_t == null)
            {
                _t = new Hashtable();
                Console.WriteLine("Hashtable created successfully.");
                return;
            }

            Console.WriteLine("Hashtable already exists.");
        }
        public Thing GetThing(string id)
        {
            var thing = new Thing(id);

            return thing;
        }

        public Hashtable GetTable()
        {
            return _t;
        }

        public void AddThing()
        {
            var id = GenerateId.GenerateUniqueId();
            // check that 1: id is not in table and 2: number of id's in table does not
            // exceed number of id's possible with given pool and id size
            while (_t.ContainsKey(id) && _t.Count < GenerateId.GetMaxEntries())
            {
                id = GenerateId.GenerateUniqueId();
                
                // TODO: add logic to change id size if table is 'full' (all id's have been exhausted)
            }
            var thing = new Thing(id);
            Console.WriteLine("ID: " + thing.GetId());
            _t.Add(thing.GetId(), thing);
        }

        public void PrintAllThings()
        {
            Console.Clear();
            var keys = _t.Keys;
            if (keys.Count == 0)
            {
                Console.WriteLine("Table has no entries");
            }
            foreach (var k in keys)
            {
                // must cast to object type first
                var t = (Thing)this._t[k];
                Console.WriteLine("Thing ID: " + t.GetId() + " Thing Number: " + t.GetNum());
            }
            
        }

        public void EmptyTable()
        {
            _t.Clear();
            Console.WriteLine("Table cleared.");
        }
    }
}