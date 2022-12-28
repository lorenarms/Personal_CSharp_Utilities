//============================================================================
// Name        : PRIVATE INPUT
// Author      : Lawrence Artl III
// Version     : 1.1.0
// Copyright   : Copyright © October 7, 2021
// Description : Input a string privately
//============================================================================

using System;
using System.Collections.Generic;
using System.Text;


namespace PrivateInputEngine
{
    class PrivateInput
    {
        private string _privateString;

        public string GetPrivateString()
        {
            return _privateString;
        }

        public void InputPrivately()
        {
            Console.Write("Type in your message privately: ");

            string tempString = "";
            do
            {
                // reads key presses from input
                ConsoleKeyInfo key = Console.ReadKey(true); 

                // check for backspace or enter key
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter) 
                {

                    // add character to temporary string
                    tempString += key.KeyChar;

                    //write a * for the character for secrecy
                    Console.Write("*"); 
                }
                else
                {
                    // backspace is pressed and the string has characters in it
                    if (key.Key == ConsoleKey.Backspace && tempString.Length > 0) 
                    {
                        // reduce the temporary string by one character each time bs is pressed
                        tempString = tempString.Substring(0, (tempString.Length - 1));
                        
                        // removes a '*' from the end of the output
                        Console.Write("\b \b");
                        
                    }
                    else if (key.Key == ConsoleKey.Enter) { break; }
                }
            } while (true);

            _privateString = tempString;
            tempString = null;
            Console.WriteLine();
            
            return;
        }
    }
}
