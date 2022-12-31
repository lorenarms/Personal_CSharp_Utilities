//============================================================================
// Name        : WORDWRAPPER
// Author      : Lawrence Artl III
// Version     : 1.0.0
// Copyright   : Copyright © 2021
// Description : Input a long string of text with spaces and wrap the content
//               appropriately in the console window
//
//               Good for text-based games or printing out long instructions
// Website     : http://artllj.com
// Github      : https://github.com/lorenarms
//============================================================================



using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace WordWrapper
{
    class Driver
    {
        public static void Main(string[] args)
        {
            // import text file with Lorem Ipsum text
            string str =
                System.IO.File
                    .ReadAllText(@"C:\Users\Lawrence\Git Repos\Personal_CSharp_Utilities\WordWrapper\lorem.txt");

            
            WriteLine(str + "\n\n");

            ReadKey();

            WordWrapper.Wrap(str);
            
            Console.WriteLine("Press Enter to Exit...");
            ReadKey();
        }
    }
}
