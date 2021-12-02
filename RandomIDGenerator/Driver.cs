using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RandomIDGenerator
{
    class Driver
    {
        public static void Main(string[] args)
        {
            Hashtable t = new Hashtable();

            
            
            
            for (int i = 0; i < 10; i++)
            {
                Object o = new object();
                String id = GenerateID.generateUniqueID();
                while (t.Contains(id))
                {
                    id = GenerateID.generateUniqueID();
                }
                
                t.Add(GenerateID.generateUniqueID(), o);
                Console.WriteLine("Hash Table count: " + t.Count);
                Thread.Sleep(1);
            }
            Console.ReadKey();

        }
    }
}
