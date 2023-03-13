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
            string file = $@"C:\Users\PanIQ Vegas Office\Desktop\Technician\sqlInsert.txt";

            Console.WriteLine("How many lines to generate?");
            string? userInput = Console.ReadLine();
            count = int.Parse(userInput);

            Console.WriteLine("Where to start?");
            string? userStart = Console.ReadLine();
            start = int.Parse(userStart);

            var SQLInputGenerator = new SQLInputGenerator();



            SQLInputGenerator.GeneratInput(start, count);

            List<string> input = SQLInputGenerator.GetInput();

            foreach (string inputItem in input)
            {
                //Console.WriteLine(inputItem);
                File.AppendAllText(file, inputItem);
            }

            Console.WriteLine("File written successfully!");

        }
    }
}