using System;
using System.Text;
using System.Collections.Generic;
using static System.Console;


namespace PrivateInputEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            // make private input object for storing private string
            var privateInput01 = new PrivateInput();
            //var privateInput02 = new PrivateInput();

            // input and store the private string
            privateInput01.InputPrivately();
            //privateInput02.InputPrivately();

            Clear();
            
            // print the private string


            Console.WriteLine("Private string: " + privateInput01.GetPrivateString());
            //Console.WriteLine("Private string: " + privateInput02.GetPrivateString());
            
            
            ReadKey();
        }

    }
}

