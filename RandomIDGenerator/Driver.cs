using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RandomIDGenerator
{
    class Driver
    {
        public static void Main(string[] args)
        {
            Table table = null;
            int sel = 0;

            while (sel != 9)
            {
                Console.WriteLine("1: Create a table" + "\n2: Add a thing" + "\n3: Print all things" + "\n4: Destroy table" 
                + "\n9: Exit");
                var selection = Console.ReadLine();
                sel = Int32.Parse(selection);

                switch (sel)
                {
                    case 1:
                    {
                        Console.Clear();
                        if (table == null) table = new Table();
                        else Console.WriteLine("Table already exists.");
                        break;
                    }
                    case 2:
                    {
                        if (table != null) table.AddThing();
                        else Console.WriteLine("Create a table first.");
                        break;
                    }
                    case 3:
                    {
                        if (table != null) table.PrintAllThings(); 
                        else Console.WriteLine("Create a table first.");
                        break;
                    }
                    case 4:
                    {
                        if (table == null) Console.WriteLine("Create a table first.");
                        else if (table.GetTable().Count == 0) Console.WriteLine("Table is already empty.");
                        else table.EmptyTable();
                        break;
                    }
                }
                {
                    
                }

            }
            
            
        }

        
    }
}
