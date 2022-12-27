//*******************************************************************
//
// GIBBERISH GENERATOR
//
// Author: Lawrence Artl III
//
// Purpose: generate a text file that contains random numbers,
// uppercase letters, or lowercase letters.
// 
//*******************************************************************


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace GibberishGenerator
{
    class Driver
    {
        static void Main(string[] args)
        {
            //TODO: add option for generating numbers or letters (capital or lowercase)
            var generator = new RandomGenerator();
            var writeLines = new WriteAllAlines();
            string textToWrite = "0";
            var inputFromMainMenu = 0;
            
            do
            {
                Clear();
                Write("CHOOSE A TYPE OF STRING:\n1: Capital letters only\n2: Lowercase letters only\n3: Numbers only\n4: Exit\n");
                string? str = ReadLine();
                int.TryParse(str, out inputFromMainMenu);



                switch (inputFromMainMenu)
                {
                    case 1:
                        textToWrite = generator.RandomString(SetLengthOfString(), false);
                        WriteLine("Your string: " + textToWrite);
                        ReadKey();
                        break;
                    case 2:
                        textToWrite = generator.RandomString(SetLengthOfString(), true);
                        WriteLine("Your string: " + textToWrite);
                        ReadKey();

                        break;
                    case 3:
                        int min = SetMinimum();
                        int max = SetMaximum(min);
                        textToWrite = generator.RandomNumber(min, max);
                        WriteLine("Your string: " + textToWrite);
                        ReadKey();

                        break;
                    case 4:
                        break;
                    default:
                        WriteLine("That is not a valid response, please try again (press 'enter')");
                        ReadKey();
                        Clear();
                        break;
                }

                

            }   while (inputFromMainMenu != 4);

            

            //TODO: add options for length of lines and number of lines


            List<string> linesToWriteToFile = new List<string> { };

            
            for (int i = 0; i < 20; i++)
            {
                var randomString = generator.RandomString(40);
                linesToWriteToFile.Add(randomString);
            }

            //TODO: add option to name file

            Task writeToFile = writeLines.WriteStringsToFile(linesToWriteToFile);

            //TODO: add loop to make a new file if desired
        }

        public static int SetLengthOfString()
        {
            Clear();
            Write("Enter a length for the string: ");
            string? str = ReadLine();
            int.TryParse(str, out int stringLength);
            if (stringLength != 0)
            {
                return stringLength;
            }
            else
            {
                WriteLine("That is not valid; default of '5' applied");
                return 5;
            }
        }

        public static int SetMinimum()
        {
            int min = 0;
            Clear();
            Write("Enter a minimum number: ");
            string? str = ReadLine();
            int.TryParse(str, out min);
            Write("\nMinimum value: " + min);
            return min;
        }

        public static int SetMaximum(int min)
        {
            int max = 0;
            Clear();
            Write("Enter a maximum number: ");
            string? str = ReadLine();
            int.TryParse(str, out max);
            if (max < min)
            {
                min += 5;
                WriteLine("That won't work; using default value of " + min);
                return min;
            }
            Write("\nMaximum value: " + max);
            return max;
        }
    }

    public class RandomGenerator
    {
        // Instantiate random number generator.  
        // It is better to keep a single Random instance 
        // and keep using Next on the same instance.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public string RandomNumber(int min, int max)
        {
            return _random.Next(min, max).ToString();
        }

        // Generates a random string with a given size.    
        public string RandomString(int size, bool lowerCase = true)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):   
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

    }

    class WriteAllAlines
    {
        public async Task WriteStringsToFile(List<string> input)
        {
           
            // writes a file to the current program directory, wherever that is
            await File.WriteAllLinesAsync(@".\RandomTextWritten.txt", input);
            
        }
    }
}


