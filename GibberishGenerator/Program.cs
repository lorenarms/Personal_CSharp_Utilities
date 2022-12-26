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
using System.Linq;
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
            //TODO: add options for length of lines and number of lines

            var generator = new RandomGenerator();
            var writeLines = new WriteAllAlines();

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
    }

    public class RandomGenerator
    {
        // Instantiate random number generator.  
        // It is better to keep a single Random instance 
        // and keep using Next on the same instance.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
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


