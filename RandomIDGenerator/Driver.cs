//============================================================================
// Name        : HASHTABLE and RANDOM ID GENERATOR
// Author      : Lawrence Artl III
// Version     : 1.0.0
// Copyright   : Copyright © 2021
// Description : Build a hashtable, add 'things', print all items, and
//              delete the table.
//
//              This program showcases the algorithm to generate unique ID's for
//              a hashtable
// Website     : http://artllj.com
// Github      : https://github.com/lorenarms
//============================================================================

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
using MenuBuilder;

namespace RandomIDGenerator
{
    internal class Driver
    {
        public static void Main(string[] args)
        {
            Table table = null;
            var sel = 0;

            while (sel != 5)
            {
                string[] menuOptions = {"Create a table" , "Add a thing" , "Print all things" , "Destroy table"
                                        , "Exit" };


                // using the MenuBuilder class
                var newMenu = new Menu(menuOptions, 1, 1);

                newMenu.ModifyMenuLeftJustified(menuOptions);

                newMenu.CenterMenuToConsole();

                newMenu.ResetCursorVisible();

                sel = newMenu.RunMenu();

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

                    // TODO: add menu option to change ID size to allow more entries in table
                }
                {
                    
                }

            }
            
            
        }

        
    }
}
