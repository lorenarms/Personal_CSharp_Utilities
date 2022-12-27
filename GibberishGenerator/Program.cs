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


using static System.Console;

namespace GibberishGenerator
{
    class Driver
    {
        static void Main(string[] args)
        {
            
            var generator = new RandomGenerator();
            var writeLines = new WriteAllLines();
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
                        textToWrite = generator.RandomString(SetLengthOfString(), SetNumberOfLines(), false);
                        WriteLine("Your string:\n" + textToWrite);
                        ReadKey();
                        break;
                    case 2:
                        textToWrite = generator.RandomString(SetLengthOfString(), SetNumberOfLines(), true);
                        WriteLine("Your string:\n" + textToWrite);
                        ReadKey();

                        break;
                    case 3:
                        textToWrite = generator.RandomNumber(SetLengthOfString(), SetNumberOfLines());
                        WriteLine("Your string:\n" + textToWrite);
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
            
            //List<string> linesToWriteToFile = new List<string> { };
           
            //TODO: add option to name file

            //Task writeToFile = writeLines.WriteStringsToFile(linesToWriteToFile);
            Task writeToFile = writeLines.WriteStringsToFile(textToWrite);

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

        public static int SetNumberOfLines()
        {
            int lines = 1;
            Clear();
            Write("Number of lines to write: ");
            string? str = ReadLine();
            int.TryParse(str, out lines);
            if (lines <= 0)
            {
                lines = 1;
                WriteLine("That won't work; using default value");
            }
            
            return lines;
        }
    }



   
}


