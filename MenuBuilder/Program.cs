


using System;
using static System.Console;

namespace Lesson_10_HashTable_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // menu options string
            string[] menuOptions =
                {"Option 1", "Another options", "A third options", "This is another option", "The last option", "Exit"};

            // build a menu object
            var newMenu = new Menu(menuOptions, 1, 1);
            
            // modify the menu for center justification
            // menu can be modified to be left justified as well
            newMenu.ModifyMenuCentered(menuOptions);
            
            // center the menu to the console;
            // this overrides the col param in initial construction
            newMenu.CenterMenuToConsole();

            // turn off the cursor blink
            newMenu.ResetCursorVisible();

            // RunMenu returns the selection

            int selection = 0;

            // this is a good place to use a switch statement for options
            while (selection != 6)      // make this your exit case
            {
                selection = newMenu.RunMenu();
                switch (selection)
                {
                    case 1:
                    {
                        Console.WriteLine("You selected option 1!");
                        //ReadKey();
                        //Clear();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("You picked the fourth option!");
                        //ReadKey();
                        //Clear();
                        break;
                    }
                    case -1:
                    {
                        Environment.Exit(0);
                        break;
                    }
                }
            }

            Console.WriteLine("Press Enter to Exit");
            ReadKey();



        }
    }
}
