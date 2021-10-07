//============================================================================
// Name        : WORD WRAPPER
// Author      : Lorenzo Dominguez
// Version     : 1.1.1
// Copyright   : Copyright © October 7, 2021
// Description : Naturally wrap the text of a long paragraph
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
            WordWrapper.Wrap("Will this wrap?");                    // test with a short phrase, will print as is

            var rand = new Random();                                // build a random string of numbers with spaces

            string newParagraph = "";
            for (int i = 0; i < WindowWidth * 5; ++i)
            {
                string charToAdd = rand.Next(0, 9).ToString();
                if (charToAdd.Equals("0"))
                {
                    charToAdd = " ";                                // string won't wrap without spaces!
                                                                    // may add functionality for that later
                }

                newParagraph += charToAdd;
            }

            WordWrapper.Wrap(newParagraph);                         // test with longer string

            
            Console.WriteLine("Press Enter to Exit...");
            ReadKey();
        }
    }
}
