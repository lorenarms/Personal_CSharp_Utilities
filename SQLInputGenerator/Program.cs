using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            int count = 3;
            int start = 0;
            string file = $@"C:\Users\Lawrence\Desktop\sqlInsert.txt";

            Console.Write("How many lines to generate? ");
            string? userInput = Console.ReadLine();
            count = int.Parse(userInput);

            
            var SQLInputGenerator = new SQLInputGenerator();



            SQLInputGenerator.GenerateInput(count);

            List<string> input = SQLInputGenerator.GetInput();

            foreach (string inputItem in input)
            {
                //Console.WriteLine(inputItem);
                try
                {
                    File.AppendAllText(file, inputItem);

                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    Console.WriteLine(ex.Message.ToString());
                }
                
            }

            Console.WriteLine("File written successfully!");

        }
    }
}